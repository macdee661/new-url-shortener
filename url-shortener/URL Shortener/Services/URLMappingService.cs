
namespace urlshorterner.Services {

    public class URLMappingService {

        char[] alphaNum = new char[] {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        Random rnd = new Random();

        public string GenerateShortenedURL(){

            string new_url = "";
            
                for (int i = 0; i < 4; i++){
                    char randChar = alphaNum[rnd.Next(0, alphaNum.Length)];
                    new_url = new_url + randChar;
                }

                return new_url;
            

        }

        public string ObtainLongUrl(string shortURL){
            
            return "www.google.com";
        }


    }


}
