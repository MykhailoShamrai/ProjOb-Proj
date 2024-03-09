namespace ProjOb_project.Parsers
{
    // Class FtrParser inherited from Parser class
    internal class FtrParser : Parser
    {
        // Overriden method for finding class identifier in line of text. In this case type of file from where was read line is .ftr file. 
        public override (string, string[]) FindClass(string line)
        {
            string[] parameters = line.Split(',');
            return (parameters[0], parameters[1..parameters.Length]);
        }
    }
}
