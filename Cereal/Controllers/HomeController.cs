using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string str = @"A is for apple, J is for Jacks. Cinnamon toasty Applejacks
            Alpha-bits you know you want them, come and have some!
            Always After My Lucky Charms- They’re Magically Delicious!
            Applejacks will not be sold to bullies
            Applejacks. Where the sweet taste of CinnaMon is the winna-mon
            Because that’s the kind of mom you are.
            Bet you can’t eat three
            Breakfast cereal with a cowboy cartoon character. Waffle-o Bill sang Get along little blueberry critters, git along.
            Breakfast of Champions
            Brings out the tiger in you, in you!
            Cream of Wheat is so good to eat, and we have it everyday. We sing this song; it will make us b, and it makes us shout, Hooray! It’s good for growing babies, and grownups too to eat. For all the family’s breakfast, you can’t beat Cream of Wheat.
            Donkey Kong! Donky Kong Cereal! Crunchy Barrels of fun for your breakfast! You’ll love that crunch!
            Follow my nose it always knows
            Fruit and Fibre. Tastes so good, you’ll forget the fiber.
            Go with the Goodness of Cheerios
            Gotta have my pops!
            He likes it! Hey Mikey!
            Hearts, stars, and horseshoes. Clovers and blue moons. Pots of gold and rainbows. And me red balloons. That’s me Lucky Charms. They’re magically delicious.
            Honey Comb’s big! Yeah, yeah, yeah! It’s not small…no, no, no!
            Honey Combs brand breakfast cereal
            I vant to eat your cereal!
            I’m Rapmaster Barney and I’m here to say, I love Fruity Pebbles in a major way!
            I’m coo-coo for Cocoa Puffs!
            It tastes like a chocolate milkshake, only crunchy!
            K-E-double-L-O-double-good, Kellogg’s best to you…
            Kid tested. Mother approved.
            Kids like Kix for what Kix has got, Moms like Kix for what Kix is not.
            Let Cocoa Krispies fill your spoon, and soon you’ll be gazing at a cocoa moon. sitting under a chocolate palm tree, by the cocoa sea.
            Life is full of surprises
            Lucky Charms. They’re magically delicious.
            Mr. T cereal! Golden flakes, crispy T’s.. one bite and you’re gonna be eatin’ with the team that’s teaming up with Mr. T!
            Now Pac-Man isn’t just a game you play, it’s a crispy corn cereal that’s coming your way! New Pac-Man! Chomp! Chomp! Delicious! There’s Inky, and Pinky, and Blinky and Clyde! We’re marshmallow bits you’ll find inside new Pac-Man! Chomp! Chomp! Delicious!”
            Nobody can say no to the honey nut O’s in Honey Nut Cheerios.
            Nutrition: Thats the Cheerios Tradition
            Oats, the Grain Highest in Protein
            Oh…those Golden Grahams… those Golden Grahams. Golden honey, just a touch, with grahams golden wheat.
            Oot-fray, Oops-lay!
            Race for the taste, the honey sweet taste!, the honey-nutty taste of Honey Nut Cheerios
            Roar, Boys, Roar, It tastes like more, What a flavor, Zippity-zow – its grand – and how!
            Shot from guns
            Show’em you’re a tiger, Show’em what you can do, the taste of Tony’s Frosted Flakes, brings out the tiger in you, in you!
            Silly Rabbit, Trix are for kids!
            Sit down to a familiar face
            Smurfberry Crunch is fun to eat; A Smurfy, fruity, breakfast treat; Made by Smurfs so happily; It tastes like crunchy Smurfberries; it’s fun to eat and tasty too; in berry red and Smurfy blue!
            Snap! Crackle! Pop!
            Start aging smart
            Sugar Bear can’t get enough.
            Take a bite, take a bite, take an Alpha-Bits bite. You can make a game out of eating every letter in sight. A, B, C…X, Y, Z.
            Taste them again, for the first time
            The best to you each morning.
            The Big G stands for Goodness
            The simpler the better
            They’re A-B-C Delicious.
            They’rrrre GR-R-REAT!
            Think smart. Think Alpha-bits cereal.
            Toasted wheat with a taste of honey
            Toasted Whole Grain Oat Cereal
            Today is the first day of the rest of our life.
            Two scoops of plump juicy raisins
            We eat what we like.
            We’re gonna tempt your tummy, with the taste of nuts and honey, its a honey of an O, it’s Honey Nut Cheerios.";

            string subTitle = SplitStr(str);
            ViewBag.MyString = subTitle;
            return View();
        }
        static string SplitStr(string str)
        {
            string[] strArr = str.Split('\n');
            Random random = new Random();
            int randomNumber = random.Next(0, strArr.Length);
            return strArr[randomNumber];
        }
    }
}
