using SimplexProject.Enums;
using System.Linq;

namespace SimplexProject.Models
{
    internal class LPTask
    {
        public double[] ObjectiveFuction;//кофіцієнти функції
        public double[,] ConstraintsMatrix;//Матриця кофіцієнтів обмежень
        public double[] ConstraintsRHS;//значення обмежень

        public RelationType[] RelationTypes;//напрямок обмеження
        public ObjectiveType Optimization;//максимізація чи мінімізація

        public LPTask(
            double[] objectiveFunction,
            double[,] constraintsMatrix,
            double[] constraintsRHS,
            RelationType[] relationTypes,
            ObjectiveType optimizationType
            )
        {
            ObjectiveFuction = objectiveFunction;
            ConstraintsMatrix = constraintsMatrix;
            ConstraintsRHS = constraintsRHS;
            RelationTypes = relationTypes;
            Optimization = optimizationType;

        }

        public int ConstraintsCount => ConstraintsMatrix.GetLength(0);
        public int VariablesCount => ObjectiveFuction.Length;

        public override string ToString()
        {
            string result = string.Empty;

            int n = ConstraintsMatrix.GetLength(0);
            int m = ConstraintsMatrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                string line = string.Join(" ", Enumerable.Range(0, m).Select(j => ConstraintsMatrix[i, j].ToString()));
                line += " " + RelationTypes[i].ToDescriptionString();
                line += " " + ConstraintsRHS[i];

                result += line + "\n";
            }

            string objectiveLine = string.Join(" ", ObjectiveFuction.Select(d => d.ToString()));
            objectiveLine += " " + Optimization.ToDescriptionString();

            result += objectiveLine;

            return result;
        }

    }
}
