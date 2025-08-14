using System;
using System.Collections.Generic;
//using TechTalk.SpecFlow;
using Reqnroll;
//using TechTalk.SpecFlow.Assist;
using Reqnroll.Assist;

namespace com.edgewords.specflow.nunit.demo.scenariocontextinjection.Steps
{
    [Binding]
    public class ScenarioSteps
    {
        //Field to hold ScenarioContext injected by Specflow
        private readonly ScenarioContext _scenarioContext;

        //Constructor accepts ScenarioContext that will be injected by specflow. Puts it in field.
        public ScenarioSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [Then(@"we write out the horizontal table")]
        public void ThenWeWriteOutTheHorizontalTable()
        {
            //Get our table back from the ScenarioContext dictionary object
            //that has been injected in here by Specflow 
            //Remember to        -> | cast | <-  from plain Object back to Table
            Table horizontaltable = (Table)_scenarioContext["HorizontalTable"];

            //We now have a specflow table we can use...
            //TableRow row = horizontaltable.Rows[0]; //TableRow datatype does not exist in Reqnroll
            DataTableRow row = horizontaltable.Rows[0];
            Console.WriteLine(row["Username"]);
            Console.WriteLine(row["Password"]);
        }
        
        [Then(@"we write out the verticle table")]
        public void ThenWeWriteOutTheVerticleTable()
        {
            Table vertialTable = (Table)_scenarioContext["VerticalTable"];

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
            Table multirowTable = (Table)_scenarioContext["MultiRowTable"];
            //Once we have the Specflow table back from _scenarioContext just use as normal...
            foreach(var row in multirowTable.Rows)
            {
                Console.WriteLine(row["Sku"]);
                Console.WriteLine(row["Name"]);
            }
        }
        
        [Then(@"we can also get at an individual rows data directly")]
        public void ThenWeCanAlsoGetAtAnIndividualRowsDataDirectly()
        {
            Table multirowTable = (Table)_scenarioContext["MultiRowTable"];
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
