﻿using SimplexProject.Converters;
using SimplexProject.Enums;
using SimplexProject.Models;
using SimplexProject.Utilities.Simplex;
using System;
using System.Collections.Generic;

namespace SimplexProject.Solvers
{
    internal class PrimalSimplexSolver
    {
        private LPTask task;
        private List<int> basicVariables;
        private double[,] tableau;
        private SimplexStep currentStep;
        private bool isOptimal;

        public PrimalSimplexSolver(LPTask task)
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
            task = StandartConverter.ConvertToStandartForm(task);
        }

        private void BuildTableau()
        {
            basicVariables = SimplexUtilities.FindBasicVariables(task.ConstraintsMatrix);
            if (basicVariables.Count != task.ConstraintsMatrix.GetLength(0))
            {
                throw new InvalidOperationException("basicVariables.Count != task.ConstraintsMatrix.GetLength(0)");
            }

            tableau = SimplexUtilities.BuildTableau(
                new ObjectiveData(task.ObjectiveFuction, task.Optimization), 
                new StandartConstraintData(task.ConstraintsMatrix, task.ConstraintsRHS), 
                basicVariables);

            isOptimal = IsOptimal();
        }

        private void PerformIteration()
        {
            int pivotColumn = SimplexUtilities.FindPivotColumn(tableau);
            int pivotRow = SimplexUtilities.FindPivotRow(tableau, pivotColumn);

            if (pivotRow == -1) throw new InvalidOperationException("The problem is unbounded.");

            tableau = SimplexUtilities.NextIteration(tableau, pivotColumn, pivotRow);
            basicVariables[pivotRow] = pivotColumn;

            isOptimal = IsOptimal();
        }

        public bool IsOptimal()
        {
            return SimplexUtilities.IsOptimal(tableau);
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
