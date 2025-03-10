﻿using SimplexProject.Converters;
using SimplexProject.Enums;
using SimplexProject.Models;
using SimplexProject.Utilities.Simplex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplexProject.Solvers
{
    internal class DualSimplexSolver
    {
        private LPTask task;
        private List<int> basicVariables;
        private double[,] tableau;
        private SimplexStep currentStep;
        private bool isOptimal;

        public DualSimplexSolver(LPTask task)
        {
            this.task = task;
            basicVariables = new List<int>();
            tableau = new double[0, 0];
            currentStep = SimplexStep.Init;
            isOptimal = false;
        }

        public SimplexStep CurrentStep => currentStep;

        public void MoveToNextStep()
        {
            switch (currentStep)
            {
                case SimplexStep.Init:
                    TransformTask();
                    currentStep = SimplexStep.Transform;
                    break;

                case SimplexStep.Transform:
                    BuildTableau();
                    currentStep = SimplexStep.BuildTableau;
                    break;

                case SimplexStep.BuildTableau:
                    if (isOptimal)
                    {
                        currentStep = SimplexStep.Complete;
                    }
                    else
                    {
                        PerformIteration();
                        currentStep = SimplexStep.Iteration;
                    }
                    break;

                case SimplexStep.Iteration:
                    if (isOptimal)
                    {
                        currentStep = SimplexStep.Complete;
                    }
                    else
                    {
                        PerformIteration();
                    }
                    break;

                case SimplexStep.Complete:
                    break;
            }
        }


        private void TransformTask()
        {
            task = StandartConverter.ConvertToDualStandartForm(task);
        }

        private void BuildTableau()
        {
            Func<double, bool> predicate;

            if (task.Optimization == ObjectiveType.Minimize)
            {
                predicate = val => val >= 0;
            }
            else
            {
                predicate = val => val <= 0;
            }

            if (!task.ObjectiveFuction.All(predicate))
            {
                throw new InvalidOperationException("There's no start solution");
            }

            basicVariables = SimplexUtilities.FindBasicVariables(task.ConstraintsMatrix);
            if (basicVariables.Count != task.ConstraintsMatrix.GetLength(0))
            {
                throw new InvalidOperationException("basicVariables.Count != task.ConstraintsMatrix.GetLength(0)");
            }

            tableau = SimplexUtilities.BuildTableau(
                new ObjectiveData(task.ObjectiveFuction, ObjectiveType.Maximize),
                new StandartConstraintData(task.ConstraintsMatrix, task.ConstraintsRHS),
                basicVariables);

            isOptimal = IsOptimal();
        }

        private void PerformIteration()
        {
            int pivotRow = SimplexUtilities.FindDualPivotRow(tableau);
            int pivotColumn = SimplexUtilities.FindDualPivotColumn(tableau, pivotRow);

            if (pivotColumn == -1) throw new InvalidOperationException("The problem is unbounded.");

            tableau = SimplexUtilities.NextIteration(tableau, pivotColumn, pivotRow);
            basicVariables[pivotRow] = pivotColumn;

            isOptimal = IsOptimal();
        }

        public bool IsOptimal()
        {
            return SimplexUtilities.IsDualOptimal(tableau);
        }

        public string GetCurrentState()
        {
            switch (currentStep)
            {
                case SimplexStep.Transform:
                    return "Transforming task to standard form.";
                case SimplexStep.BuildTableau:
                    return "Building initial simplex tableau.";
                case SimplexStep.Iteration:
                    return "Performing simplex iteration.";
                case SimplexStep.Complete:
                    return "Solution is complete.";
                default:
                    return "Unknown state.";
            }
        }


        public object GetDisplayData()
        {
            if (currentStep == SimplexStep.Transform)
            {
                return GetTask();
            }
            else if (currentStep == SimplexStep.BuildTableau || currentStep == SimplexStep.Iteration)
            {
                return GetTableau();
            }
            else if (currentStep == SimplexStep.Complete)
            {
                return GetSolution();
            }
            return new object(); 
        }


        private object GetTask()
        {
            return new
            {
                Task = task,
            };
        }

        private object GetSolution()
        {
            int variablesCount = tableau.GetLength(1) - 1;
            double[] solution = new double[variablesCount];

            for (int i = 0; i < basicVariables.Count; i++)
            {
                solution[basicVariables[i]] = tableau[i, variablesCount];
            }

            return new
            {
                Solution = solution,
                OptimalValue = tableau[tableau.GetLength(0) - 1, tableau.GetLength(1) - 1],
            };
        }

        private object GetTableau()
        {
            var data = new
            {
                Tableau = tableau,
                BasicVariables = basicVariables,
            };
            return data;
        }
    }
}
