using System.Collections.Generic;

namespace Paradigm
{
    class Details
    {
        public string about;
        public List<string> team;
        public List<string> rules;
        public List<Contacts> contacts;
    }

    class Contacts
    {
        public string name;
        public string number;

        public Contacts(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
    }

    static class DataProvider
    {
        static public Dictionary<string, Details> eventDetails;

        static DataProvider()
        {
            Details codeHunt = new Details()
            {
                about = "Hunt your way out with coding clues and tasks before the ultimate coding showdown.",
                team = new List<string>(new string[] {
                    "Upto 3 participants in a team."
                }),
                rules = new List<string>(new string[] { 
                    "Preliminary round will resemble a treasure hunt with coding clues or tasks.",
                    "Final round will be a hardcore coding showdown.",
                    "The preliminary round’s treasure hunt locations will be easy and close to locate and hence help from third persons to decode the clues will lead to rejection.",
                    "Decision taken by the event panel will be final."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Mukundram", "9500065861"),
                    new Contacts("Raghuram", "9566358578"),
                })
            };

            Details codeTheBot = new Details()
            {
                about = "Are you a computer geek who is tired of conventional coding competitions? Or are you a person who loves to play games? Are you someone is innovative and creative? " + 
                        "\n\nYou’ve come to the right place." + 
                        "\n\nRobots have never failed to fascinate people. Here’s the chance to code your own bot. No pre-requisite knowledge on robotics or robot design is needed! With your whole heart, code the bot and win the jackpot !! ",
                rules = new List<string>(new string[] { 
                    "1st round consists of coding the bot, which will be simulated in a virtual environment (online). ",
                    "Teams selected for the next round will be coding the real bots to complete a real time task. ",
                    "Top three teams based on their scores will be finally awarded. ",
                    "Any teams indulging in malpractices will be disqualified. ",
                    "The event coordinators reserve the right to make modifications to any of the rules if deemed necessary. ",
                    "In case of any discrepancies, the organisers' decision will be considered final. ",
                    "Knowledge of C,C++ is enough!!"
                }),
                team = new List<string>(new string[] {
                    "Each team can consist of a maximum of 3 members. ",
                    "Each team should have unique participants i.e. no two teams can have even a single participant common. ",
                    "The team members can be from different institutions"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Jayashree S", "9176889486"),
                    new Contacts("Hariharan S", "7299752105"),
                })
            };

            Details dumbC = new Details()
            {
                about = "Are you one of the dumb guys? Perfect. Sometimes it’s wise to remain dumb. Like during Dumb C." + 
                        "\n\nYou’ve played it just for fun a billion times. Now, all you have to do is be silent and let prizes fall at your feet.",
                rules = new List<string>(new string[] { 
                    "Only action, no lip movement is allowed.",
                    "Totally 2 rounds followed by finals.",
                    "Each round is an elimination round.",
                    "1st round has 7 words from different fields ( Time: 2 mins ).",
                    "2nd round has 5 Technical words (Time: 1.30 mins ).",
                    "Finals will be a surprise round containin2g many sub-rounds.",
                    "Prize money will be rewarded to the top 3 teams"
                }),
                team = new List<string>(new string[] {
                    "It is a freestyle and an informal event.",
                    "Teams are flexible"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Chaaran S", "9445549713"),
                    new Contacts("Rathish", "9176278215"),
                })
            };

            Details informals = new Details()
            {
                about = "So you just wanna have fun? Had enough of tech-talk? Coding? Testing? Debugging?" + 
                        "\n\nThen INFORMALS ku vaanga ji, vaanga ji, vaanga ji! " + 
                        "\n\nEnjoy panalam :P",
                rules = new List<string>(new string[] { 
                    "There are no rules. Just fun fun and lots of fun."
                }),
                team = new List<string>(new string[] {
                    "There is no restriction on teams.",
                    "It is just an informal event"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("K Abdul Azharudeen", "9176227673"),
                    new Contacts("Sasi Kumar", "9791128719"),
                })
            };

            Details onlineCoding = new Details()
            {
                about = "Hello to all coders out there. We introduce to you, Paradigm's online coding competition, in association with Codechef, one of the best platforms out there for competitive coding. Participate and leverage your skill to win exciting prices. " + 
                        "\n\nA good coder gets it right the first run. A great coder learns from every last run. At the least, you can learn a lot from the questions here and gain more knowledge. ",
                rules = new List<string>(new string[] { 
                    "There will be 5 problems. ",
                    "1 point for each problem solved (should pass all test cases).",
                    "Tie breakers will take into account wrong submissions and time taken.",
                    "The contest will be held in Codechef platform. Each participant must have a Codechef account to participate. ",
                    "Please do not discuss strategy, suggestions or tips in the comments during a live contest. Posting questions, clarifying the problem statement is allowed."
                }),
                team = new List<string>(new string[] {
                    "Must be individual participation. No teams.",
                    "The event is open to all college students, even students from SSN can participate",
                    "Please register in our site with the same information that you have in your Codechef account. Only this way, you can win prizes."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Mukundram", "9500065861"),
                    new Contacts("S Vignesh", "9790760608"),
                })
            };

            Details onlinePhotography = new Details()
            {
                about = "Are you always looking for reasons to pick up a camera and take pictures of anything and everything? Well, we’ll give you a reason. " + 
                        "\n\nSend in captivating photos that capture the light and have a focus on colours to win prizes!" + "\n\n" +
                        "Theme: Colours, Light" + "\n" +
                        "Email: spc.paradigm2k15@gmail.com" + "\n" +
                        "Deadline: Aug 27th",
                rules = new List<string>(new string[] { 
                    "Photos should be based on either in the mentioned theme.",
                    "Send in your Name, contact number, college and department details with the entries.",
                    "There is no limit for number of entries per contestant.",
                    "Photos with proof of heavy post-processing will be eliminated.",
                    "A winner will be declared for each category based on FACEBOOK LIKES and JURY DECISION"
                }),
                team = new List<string>(new string[] {
                    "It is an individual event",
                    "Your camera is your best friend and your only team-mate"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Ashwin Alagappan", "9840712819"),
                    new Contacts("Vaibhav", "8940867220"),
                })
            };

            Details onlineQuiz = new Details()
            {
                about = "Expert at Googling ? Love trivia? Have fun connecting the dots? Say hello to the Online Quiz of Paradigm 2k15! " + 
                        "\n\nWe will put up 5-10 questions at a fixed time every day.  Be the first to get it right and earn points. Leader boards will be maintained from the beginning. Top the board on the last day and you win !",
                rules = new List<string>(new string[] { 
                    "Questions will be posted on the page",
                    "Answers should be entered as comments.",
                    "First three to give the correct answer will earn points.",
                }),
                team = new List<string>(new string[] {
                    "This is an individual participation event."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Karthik Pasagada", "9176143688"),
                    new Contacts("Naveen H", "9444466643"),
                })
            };

            Details onlineTreasureHunt = new Details()
            {
                about = "Conduct online searches, spend time on Google, play with decryption and get to know the world around you ." + 
                        "\n\nIn short, unleash the Sherlock in you !" + 
                        "\n\nTrespass each level with valid answers and prove yourself worthy for the treasure that awaits. ",
                rules = new List<string>(new string[] { 
                    "Starts on 23-AUG-2015 06:00 PM IST"
                }),
                team = new List<string>(new string[] {
                    "Online event. There are no teams and every man is for himself."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Lokkeshwaran J", "8608420067"),
                    new Contacts("Seshathiri R", "9940453069"),
                })
            };

            Details openProgramming = new Details()
            {
                about = "Open programming is a scenario based programming event. It extends through the day, so your team is welcome at any time. " + 
                        "\n\nIn the allotted 30 minutes, code like crazy and crack the two scenarios. Sounds simple doesn't it? Well, what are you waiting for? Register now.",
                rules = new List<string>(new string[] { 
                    "Timing : 30 mins",
                    "Two questions - one easy, and another umm... ‘not so easy’",
                    "Languages : C , C++, Java",
                    "Scoring based on number of test cases solved."
                }),
                team = new List<string>(new string[] {
                    "2 members per team"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Divya Brindha", "8939431579"),
                    new Contacts("Nandhini V", "9940094861"),
                })
            };

            Details paperPresentation = new Details()
            {
                about = "It’s that time of the year to witness the battle of brains. " + 
                        "\n\nWe, the Paper Presentation team of Paradigm 2k15 invite papers proposing novel and non-trivial ideas and research works in any CSE domain. " + 
                        "\n\nHere is an outstanding opportunity to unleash the genius in you and learn a lot by interacting with other enthusiasts like you." + 
                        "\n\nShow the world your research! Let them know who’s the next Einstein!! " + "\n\n\n" +
                        "Email : paradigmpaper2k15@gmail.com" + "\n" + 
                        "Last Date : 27th August" + "\n" +
                        "Acceptance : 30th August" + "" + "\n\n\n" +
                        "Format of Email : " + "\n" +
                        "⛨ The subject must be the title of the paper." + "\n" +
                        "⛨ The body of the mail should include - Name and Institute of participant (starting from the first author and going till the third one), Department and Year, Contact numbers, Email addresses." + "\n" +
                        "⛨ Send the paper as an attachment.",
                rules = new List<string>(new string[] { 
                    "Only CS domains are encouraged.",
                    "We take plagiarism very seriously. Only original research works are accepted.",
                    "The paper must not have been presented or published anywhere else.",
                    "The paper must be sent through mail.",
                    "The paper must be in two column IEEE format. This format must be strictly adhered to.",
                    "The paper length must be limited to 6 pages.",
                    "The paper must be in .pdf or .doc or .docx formats.",
                }),
                team = new List<string>(new string[] {
                    "Maximum of 3 authors and only student authors allowed. It is not a necessity that all the authors must be from the same institute."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Sanjana Sahayaraj", "9176402685"),
                    new Contacts("Jayashri Murugan", "9751653169"),
                })
            };

            Details programmingAndDebugging = new Details()
            {
                about = "Do you consider programming an art? Do you think codes are beautiful? Then this the event is for you code-blooded people. " + 
                        "\n\nProgramming and debugging is the contest for geeks to show off their grasp on programming and learn more in the process. " + 
                        "\n\nDrop in and ‘Grow Strong’ in Algorithms and Data Structures. ",
                rules = new List<string>(new string[] { 
                    "ROUND 1 : 20 Questions based on C/C++/Java languages to be answered in 15 minutes. ",
                    "In case of a tie, starred questions will be considered.",
                    "Top 8 teams of this round will qualify for the finals.",
                    "ROUND 2 : In this round you have to solve 5 questions (2-Programming, 2-Debugging, 1-Reverse Coding) in 2 hours.",
                    "Winners will be decided based on number of correctly solved problems and also efficiency of the code."
                }),
                team = new List<string>(new string[] {
                    "Each team can have a maximum of three members and minimum of two.",
                    "Teams involved in any kind of malpractice will be immediately disqualified.",
                    "No contestant can be a member of more than one team.",
                    "Decisions made by the judges will be final."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Mohana Priya K", "9003957704"),
                    new Contacts("Revanth K", "7401304804"),
                })
            };

            Details databaseDesigning = new Details()
            {
                about = "Are you the master of database and management systems? Can you mend complex queries and solve challenging real-life scenarios? " + 
                        "\n\nThen catch the buzz at SEQUEL! Show us your smarts and win exciting cash rewards!!",
                rules = new List<string>(new string[] { 
                    "Prelims: 30 questions in 20 minutes - a written assessment test where students are tested on their basics of SQL Queries.",
                    "Finals: complex query processing techniques like triggers, procedures, joins, nested queries and so on."
                }),
                team = new List<string>(new string[] {
                    "Max of three per team"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Sravanthi ", "9444731779"),
                    new Contacts("Varun Bezam", "8056032025"),
                })
            };

            Details techQuiz = new Details()
            {
                about = "Are you a tech enthusiast? Do you like connecting the dots? Do you love quizzing ? Or do you want to test how much you know ? Then Paradigm’s Tech Quiz is the place to be. " + 
                        "\n\nBy the end of it, you are guaranteed to learn some fascinating new facts. Another perk: no coding knowledge necessary. " + 
                        "\n\nCome prepared to have fun.",
                rules = new List<string>(new string[] { 
                    "There will be 2 rounds.",
                    "Prelims will be written round",
                    "Finals will be an on stage quiz"
                }),
                team = new List<string>(new string[] {
                    "This is a team event, with 2 or 3 per team. Lone wolves can find a team mate on the spot."
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Margret", "9940427171"),
                    new Contacts("Naveen", "9444466643"),
                })
            };

            Details triAthlon = new Details()
            {
                about = "You think you’re a coder huh? Think you can compete with the best of them? " + 
                        "\n\nTriathlon. Teams from colleges all over India. Three will walk out with cash prizes. " + 
                        "\n\nDo you dare to tri?",
                rules = new List<string>(new string[] { 
                    "PRELIMS : A set of not-so-technical-not-so-non-technical MCQs to be solved in 30 minutes.",
                    "Crack as many as you can to get through.",
                    "Top 12 teams qualify to the finals.",
                    "There will be a three round final",
                    "ROUND 1: One on One Connexions Face off",
                    "ROUND 2: Code Obfuscation and Reverse Coding.",
                    "ROUND 3: Core Programming",
                    "Top 3 teams will receive cash prize"
                }),
                team = new List<string>(new string[] {
                    "Each team MUST consist of THREE members.",
                    "Lone wolves and duos are not permitted. Sorry!",
                    "PS: If you don’t have a team, we can find you one ;)"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Sukanya", "9677079548"),
                    new Contacts("Srividhya", "9445974027"),
                    new Contacts("Abirami", "9962827899"),
                    new Contacts("Archana", "7708787748"),
                    new Contacts("Sharath", "8056288849"),
                    new Contacts("Sujana", "9176383296")
                })
            };

            Details uiDesign = new Details()
            {
                about = "Design dazzling user interfaces for every purpose. Here the first impression is the best impression. Your sole aim is to optimize the user experience. " + 
                        "\n\nCan you keep the interaction simple, despite a glorious UI?",
                rules = new List<string>(new string[] { 
                    "Keep the interface simple. ",
                    "Use color and  texture strategically.  ",
                    "The information content must be  conveyed quickly and accurately.",
                    "Be purposeful in page layout.  Consider the spatial relationships between items on the page and structure the page based on importance.  ",
                    "Make the UI contents detectable by using common elements in your UI so that users feel more comfortable and are able to get things done more quickly.  ",
                    "There will be two rounds",
                    "Internet will be provided for the first 10 minutes of the first round and not for the second round",
                    "Pictures, fonts etc,. will be provided for the second round"
                }),
                team = new List<string>(new string[] {
                    "Max 3 per Team(each one should be registered ) ",
                    "Mixed teams are allowed ",
                    "Team can consist of  members from Different colleges also .",
                    "Lone Wolves are welcome !!"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Dinesh Raj", "8754434808"),
                    new Contacts("Narendra Pradeep", "8903858540")
                })
            };

            Details webDesign = new Details()
            {
                about = "Are you the budding web developer waiting to prove your flair?" + 
                        "\n\nCan you design seamless websites with quirky creativity?" + 
                        "\n\nWeb Zeal is the place for you." + 
                        "\n\nAnd win handsome cash awards and other amazing prizes",
                rules = new List<string>(new string[] { 
                    "Show your skills in JavaScript, CSS3, Bootstrap",
                    "Bootstrap round will be a tutorial followed by a test",
                    "Prelims round : 20 minute paper based test",
                    "Final round : Hands on designing round, topics are those mentioned above. "
                }),
                team = new List<string>(new string[] {
                    "Teams of 1 or 2 participants are allowed"
                }),
                contacts = new List<Contacts>(new Contacts[] { 
                    new Contacts("Aakansha Prasad", "7708230559"),
                    new Contacts("Sriranjitha", "9444970070")
                })
            };



            eventDetails = new Dictionary<string, Details>();
            eventDetails.Add("Code Hunt", codeHunt);
            eventDetails.Add("Code the Bot", codeTheBot);
            eventDetails.Add("Dumb C", dumbC);
            eventDetails.Add("Informals", informals);
            //eventDetails.Add("Online Coding", onlineCoding);
            //eventDetails.Add("Online Photography", onlinePhotography);
            //eventDetails.Add("Online Quiz", onlineQuiz);
            //eventDetails.Add("Online Treasure Hunt", onlineTreasureHunt);
            eventDetails.Add("Open Programming", openProgramming);
            eventDetails.Add("Paper Presentation", paperPresentation);
            eventDetails.Add("Programming and Debugging", programmingAndDebugging);
            eventDetails.Add("Sequel", databaseDesigning);
            eventDetails.Add("Tech Quiz", techQuiz);
            eventDetails.Add("TriAthlon", triAthlon);
            eventDetails.Add("UI Design", uiDesign);
            eventDetails.Add("Web Zeal", webDesign);
        }

    }
}
