using SimplexProject.Converters;
using SimplexProject.Enums;
using SimplexProject.Models;
using SimplexProject.Solvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplexProject.Enums;
using SimplexProject;
using SimplexProject.Models;
namespace Lr3Math
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double[] ObjectiveFuction;//кофіцієнти функції
        public double[,] ConstraintsMatrix;//Матриця кофіцієнтів обмежень
        public double[] ConstraintsRHS;//значення обмежень

        public RelationType[] RelationTypes;//напрямок обмеження
        public ObjectiveType Optimization;//максимізація чи мінімізація
        private void button1_Click(object sender, EventArgs e)
        {
            int rowCount = int.Parse(textBox1.Text);
            int colCount = int.Parse(textBox2.Text);

            dataGridViewInput.ColumnCount = colCount;
            dataGridViewInput.RowCount = rowCount;
            for (int i = 0; i < colCount; i++)
            {
                dataGridViewInput.Columns[i].HeaderText = $"x{i + 1}";
            }
            DataGridViewComboBoxColumn relationColumn = new DataGridViewComboBoxColumn();
            relationColumn.Name = "Relation";
            relationColumn.HeaderText = "Relation";
            relationColumn.Items.AddRange("<=", ">=", "=");
            dataGridViewInput.Columns.Add(relationColumn);

            dataGridViewInput.Columns.Add("RHS", "RHS");

            dataGridViewInput.RowCount = rowCount;
            dataGridViewInput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewInput.AllowUserToResizeColumns = false;
            dataGridViewInput.AllowUserToResizeRows = false;

            dataGridViewInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        private void ReadDataFromGrid()
        {
            int rowCount = dataGridViewInput.RowCount;
            int colCount = dataGridViewInput.ColumnCount - 2;
            ObjectiveFuction = ParseObjectiveFunctionCoefficients(txtObjectiveFunction.Text, colCount);
            ConstraintsMatrix = new double[rowCount, colCount];
            ConstraintsRHS = new double[rowCount];
            RelationTypes = new RelationType[rowCount];

            for (int i = 0; i < rowCount - 1; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    ConstraintsMatrix[i, j] = double.Parse(dataGridViewInput[j, i].Value?.ToString() ?? "0");
                }
                string relation = dataGridViewInput[colCount, i].Value?.ToString() ?? "=";
                RelationTypes[i] = ParseRelation(relation);
                ConstraintsRHS[i] = double.Parse(dataGridViewInput[colCount + 1, i].Value?.ToString() ?? "0");
            }
            Optimization = radioMaximize.Checked ? ObjectiveType.Maximize : ObjectiveType.Minimize;
        }

        private double[] ParseObjectiveFunctionCoefficients(string text, int expectedCount)
        {
            string[] parts = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != expectedCount)
            {
                throw new ArgumentException($"Please enter exactly {expectedCount} coefficients separated by spaces.");
            }

            double[] coefficients = new double[expectedCount];
            for (int i = 0; i < expectedCount; i++)
            {
                coefficients[i] = double.Parse(parts[i]);
            }

            return coefficients;
        }

        private RelationType ParseRelation(string relationSymbol)
        {
            if (relationSymbol == "<=")
            {
                return RelationType.LessEqual;
            }
            else if (relationSymbol == ">=")
            {
                return RelationType.GreaterEqual;
            }
            else if (relationSymbol == "=")
            {
                return RelationType.Equal;
            }
            else
            {
                throw new ArgumentException("Invalid relation symbol");
            }
        }
        private void PrintTableau(dynamic data)
        {
            double[,] tableau = data.Tableau;
            List<int> basicVariables = data.BasicVariables;

            int width = tableau.GetLength(1);
            int height = tableau.GetLength(0);

            dataGridViewOutput.Columns.Clear();
            dataGridViewOutput.Rows.Clear();
            if (AllPartsGrid.Columns.Count == 0)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    AllPartsGrid.Columns.Add($"x{j + 1}", $"x{j + 1}");
                }
                AllPartsGrid.Columns.Add("RHS", "RHS");
            }
            for (int j = 0; j < width - 1; j++)
            {
                dataGridViewOutput.Columns.Add($"x{j + 1}", $"x{j + 1}");
            }
            dataGridViewOutput.Columns.Add("RHS", "RHS");
            for (int i = 0; i < height; i++)
            {
                List<object> rowValues = new List<object>();
                if (i < height - 1)
                {
                    rowValues.Add($"x{basicVariables[i] + 1}");
                }
                else
                {
                    rowValues.Add("Z");
                }
                for (int j = 0; j < width; j++)
                {
                    rowValues.Add(Math.Round(tableau[i, j], 2));
                }

                dataGridViewOutput.Rows.Add(rowValues.ToArray());
                AllPartsGrid.Rows.Add(rowValues.ToArray());
            }
            AllPartsGrid.Rows.Add(new DataGridViewRow());
            dataGridViewOutput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewOutput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    AllPartsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllPartsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        private void PrintSolution(dynamic data)
        {
            double[] solution = data.Solution;
            double optimalValue = data.OptimalValue;

            listBoxOutput.Items.Clear();
            listBoxOutput.Items.Add("Solution:");

            for (int j = 0; j < solution.Length; j++)
            {
                listBoxOutput.Items.Add($"x{j + 1} = {Math.Round(solution[j], 2)}");
            }
            listBoxOutput.Items.Add($"Optimal Value: {Math.Round(optimalValue, 2)}");
        }

        private DualSimplexSolver solver;
        private LPTask task;
        private bool isInitialized = false;


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Text = "->";
                if (!isInitialized)
                {
                    ReadDataFromGrid();

                    task = new LPTask
                    (
                        ObjectiveFuction = ObjectiveFuction,
                        ConstraintsMatrix = ConstraintsMatrix,
                        ConstraintsRHS = ConstraintsRHS,
                        RelationTypes = RelationTypes,
                        Optimization = Optimization
                    );

                    solver = new DualSimplexSolver(task);
                    isInitialized = true;
                }
                solver.MoveToNextStep();
                dynamic data = solver.GetDisplayData();

                if (solver.CurrentStep == SimplexStep.Transform)
                {
                    // PrintTask(data); // можна викликати метод для виводу задачі
                }
                else if (solver.CurrentStep == SimplexStep.BuildTableau || solver.CurrentStep == SimplexStep.Iteration)
                {
                    PrintTableau(data);
                }
                else if (solver.CurrentStep == SimplexStep.Complete)
                {
                    PrintSolution(data); 
                    button2.Enabled = false;
                    button2.Text = "Completed";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}