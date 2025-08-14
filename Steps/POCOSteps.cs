using com.edgewords.specflow.nunit.demo.scenariocontextinjection.POCOs;
using System;
//using TechTalk.SpecFlow;
using Reqnroll;

namespace com.edgewords.specflow.nunit.demo.scenariocontextinjection.Steps
{
    [Binding]
    public class POCOSteps
    {
        //Using custom POCOs
        private readonly HorizontalTablePOCO horizontalTableShared;
        private readonly VerticalTablePOCO verticalTableShared;

        public POCOSteps(HorizontalTablePOCO horizontalTableShared, VerticalTablePOCO verticalTableShared)
        {
            this.horizontalTableShared = horizontalTableShared;
            this.verticalTableShared = verticalTableShared;
        }


        [Then(@"we access the horizontal POCO")]
        public void ThenWeAccessTheHorizontalPOCO()
        {
            Console.WriteLine(horizontalTableShared.Username);
            Console.WriteLine(horizontalTableShared.Password);
        }

        [Then(@"we access the vertical POCO")]
        public void ThenWeAccessTheVerticalPOCO()
        {
            Console.WriteLine(verticalTableShared.FirstName);
        }

    }
}
