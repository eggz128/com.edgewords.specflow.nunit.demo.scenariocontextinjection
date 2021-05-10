using System;
using System.Collections.Generic;
using System.Text;

namespace com.edgewords.specflow.nunit.demo.scenariocontextinjection.POCOs
{
    public class ProductCatalogue
    {
        private MultiRowTablePOCO products;

        public MultiRowTablePOCO Products { get => products; set => products = value; }
    }
}
