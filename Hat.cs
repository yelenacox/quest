namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription
        {
            get
            {
                string shininess = "";
                switch (ShininessLevel)
                {
                    case < 2:
                        shininess = "dull";
                        break;
                    case >= 2 and <= 5:
                        shininess = "noticeable";
                        break;
                    case >= 6 and <= 9:
                        shininess = "bright";
                        break;
                    case > 9:
                        shininess = "blinding";
                        break;


                }
                return $"The hat is {shininess}.";

            }
        }
    }



}