namespace fileProcess
{
    public class Class1
    {
        public static Dictionary<string, Dictionary<string, double>> processTime (List<List<string>> list)
        {
            int indexModelName = 4;
            int indexExchangeName= 3;
            int indexTime = 1;

            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>>();

            foreach (List<string> item in list)
            {
                if (item[0] == "UpdateExchangeAsync" || item[0] == "UpdateExchangeAsync:GenerateViewableAsync")
                {
                    string modelName = item[indexModelName];
                    string exchangeName = item[indexExchangeName];
                    double executionTime = double.Parse(item[indexTime]);
                  
                    if (!result.ContainsKey(modelName))
                    {                     
                        result[modelName] = new Dictionary<string, double>();
                    }

                    if (result[modelName].ContainsKey(exchangeName))
                    {
                        result[modelName][exchangeName] += executionTime;
                    }
                    else
                    {
                        result[modelName][exchangeName] = executionTime;
                    }
                }
            }
            return result;
        }

        public static List<List<string>> ReadCSV(string filePath)
        {
            List<List<string>> data = new List<List<string>>();

            foreach (string line in File.ReadLines(filePath))
            {        
                data.Add(new List<string>(line.Split(',')));
            }

            return data;
        }
    }
}
