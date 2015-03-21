using System.Collections.Generic;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class ExerciseViewModels
    {

        public ClimateChartViewModel ClimateChartVM { get; set; }
        public QuestionViewModel QuestionListVM { get; set; }
        public ExampleViewModel ExampleVM { get; set; }
        public DeterminateTableViewModel DeterminateTableVM { get; set; }
        public SelectVegetationViewModel SelectVehetationVM { get; set; }
        public ClimateChart Chart { get; set; }
        public DeterminateTable Table { get; set; }
        public List<Parameter> Parameters { get; set; }


        public ExerciseViewModels(ClimateChart c, DeterminateTable table)
        {
            //Initialisatie
            Chart = c;
            Table = table;
            Parameters = new List<Parameter>();


            //ViewModels aanmaken
            ClimateChartVM = new ClimateChartViewModel(c, table, Parameters); //table eventueel eruit
            foreach (Parameter p in Parameters)
            {
                QuestionListVM = new QuestionViewModel(c, p);
            }
            ExampleVM = new ExampleViewModel();
            DeterminateTableVM = new DeterminateTableViewModel();
            SelectVehetationVM = new SelectVegetationViewModel();
        }
    }
}