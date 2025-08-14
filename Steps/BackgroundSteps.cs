using System;
//using TechTalk.SpecFlow;
using Reqnroll;
using com.edgewords.specflow.nunit.demo.scenariocontextinjection.POCOs;
//using TechTalk.SpecFlow.Assist;
using Reqnroll.Assist;
using System.Collections.Generic;

namespace com.edgewords.specflow.nunit.demo.scenariocontextinjection.Steps
{
    [Binding]
    public class BackgroundSteps
    {
        //Using Specflows ScenarioContext object to pass around data
        private readonly ScenarioContext _scenarioContext;

        //Using custom POCOs
        private readonly HorizontalTablePOCO horizontalTableShared;
        private readonly VerticalTablePOCO verticalTableShared;


        //Field for unpacking in this class
        private HorizontalTablePOCO localHorizontalTablePOCO;
        private VerticalTablePOCO localVerticalTablePOCO;
        


        public BackgroundSteps(ScenarioContext scenarioContext,
            HorizontalTablePOCO horizontalTableShared, VerticalTablePOCO verticalTableShared) //Added arguments for POCO sharing
        {
            //for Specflows ScenarioContext object sharing
            _scenarioContext = scenarioContext;

            //POCO sharing
            this.horizontalTableShared = horizontalTableShared;
            this.verticalTableShared = verticalTableShared;
        }


        [Given(@"an inline horizontal table with one row of data like this")]
        public void GivenAnInlineHorizontalTableWithOneRowOfDataLikeThis(DataTable table)
        {
            //Put the whole table in to a ScenarioContext object with a dictonary key
            _scenarioContext["HorizontalTable"] = table;
            //Pro: Easy | Con: Ugly unpacking is done elsewhere 

            //Using POCO
            //First use CreateInstance to unpack the data in to our local custom POCO
            //This must be done in to a field accessible to *this* class

            localHorizontalTablePOCO = table.CreateInstance<HorizontalTablePOCO>();
            horizontalTableShared.Username = localHorizontalTablePOCO.Username;
            horizontalTableShared.Password = localHorizontalTablePOCO.Password;

            //Or read table values directly in to the POCO that will be injected in to other classes
            //TableRow row = table.Rows[0];
            //horizontalTableShared.Username = row["Username"];
            //horizontalTableShared.Password = row["Password"];




        }

        [Given(@"or an inline vertical table like this")]
        public void GivenOrAnInlineVerticalTableLikeThis(DataTable table)
        {
            _scenarioContext["VerticalTable"] = table;

            //CreateInstance is smart - it can recognise and deal with vertical tables with ease
            localVerticalTablePOCO = table.CreateInstance<VerticalTablePOCO>();
            verticalTableShared.FirstName = localVerticalTablePOCO.FirstName;
            verticalTableShared.LastName = localVerticalTablePOCO.LastName;
            verticalTableShared.Age = localVerticalTablePOCO.Age;


        }
        
        [Given(@"even a table with multpile rows")]
        public void GivenEvenATableWithMultpileRows(DataTable table)
        {
            _scenarioContext["MultiRowTable"] = table;

            //CreateSet for multirows
            //multiRowTablePOCOSet = table.CreateSet<MultiRowTablePOCO>();
            IList<MultiRowTablePOCO> productlist = (IList<MultiRowTablePOCO>)table.CreateSet<MultiRowTablePOCO>();




        }
    }
}
