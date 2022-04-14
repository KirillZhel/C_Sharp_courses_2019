namespace CSharpCourse_part4
{
    public class ChessPlayer
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, " +
                $"from {Country}, born in {BirthYear}";
        }

        public static ChessPlayer ParseFideCSV(string line)
        {
            //получаем из строки line набор строк parts
            //считая, что разделителем частей будет точка с запятой
            string[] parts = line.Split(';');

            return new ChessPlayer()
            {
                Id = int.Parse(parts[0]),
                LastName = parts[1].Split(',')[0].Trim(),
                FirstName = parts[1].Split(',')[1].Trim(),
                Country = parts[3],
                Rating = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6])
            };
        }
    }
}
