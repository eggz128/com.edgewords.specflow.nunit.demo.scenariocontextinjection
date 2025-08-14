using System;
using System.Collections.Generic;
using Reqnroll;
using Reqnroll.Assist;

namespace com.edgewords.specflow.nunit.demo.scenariocontextinjection.Steps
{
    [Binding]
    public class ScenarioSteps
    {
        //Field to hold injected ScenarioContext 
        private readonly ScenarioContext _scenarioContext;

        //Constructor accepts ScenarioContext that will be injected. Puts it in field.
        public ScenarioSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"we write out the horizontal table")]
        public void ThenWeWriteOutTheHorizontalTable()
        {
            //Get our table back from the ScenarioContext dictionary object
            //that has been injected into the constructor
            //Remember to               -> | cast | <-  from plain Object back to Table
            DataTable horizontaltable = (DataTable)_scenarioContext["HorizontalTable"];

            //We now have a DataTable we can use...
            DataTableRow row = horizontaltable.Rows[0];
            Console.WriteLine(row["Username"]);
            Console.WriteLine(row["Password"]);
        }
        
        [Then(@"we write out the verticle table")]
        public void ThenWeWriteOutTheVerticleTable()
        {
            Table vertialTable = (DataTable)_scenarioContext["VerticalTable"];

            //Unpack the table in to a dictionary (key,value pairs)
            var dictionary = new Dictionary<string, string>();
            foreach (var row in vertialTable.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }

            //Use dictionary
            Console.WriteLine(dictionary["FirstName"]);
            Console.WriteLine(dictionary["LastName"]);
            Console.WriteLine(dictionary["Age"]);
        }
        
        [Then(@"we loop through multirow table")]
        public void ThenWeLoopThroughMultirowTable()
        {
            DataTable multirowTable = (DataTable)_scenarioContext["MultiRowTable"];
            //Once we have the DataTble back from _scenarioContext just use as normal...
            foreach(var row in multirowTable.Rows)
            {
                Console.WriteLine(row["Sku"]);
                Console.WriteLine(row["Name"]);
            }
        }
        
        [Then(@"we can also get at an individual rows data directly")]
        public void ThenWeCanAlsoGetAtAnIndividualRowsDataDirectly()
        {
            DataTable multirowTable = (DataTable)_scenarioContext["MultiRowTable"];
            var data = multirowTable.Rows[1];
            Console.WriteLine(data["Sku"]);
        }
        
        [Then(@"this step needs context injection to also have access to data")]
        public void ThenThisStepNeedsContextInjectionToAlsoHaveAccessToData()
        {
            _scenarioContext.Pending();
        }

    }
}
