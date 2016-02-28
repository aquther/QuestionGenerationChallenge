using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuestionGenerationChallenge
{
    
    class Question
    {
        
        Random r1 = new Random(Guid.NewGuid().GetHashCode());
        private int firstOperand;
        private int secondOperand;
        private int sum;
        private int wrongOne=1;
        private int wrongTwo=1;
        private int wrongThree=1;
        private int n;
        
        public Question(int lower,int upper)
        {
            
            sum = r1.Next(lower, upper);
            firstOperand = r1.Next(0, sum);
            secondOperand = sum - firstOperand;

            while((wrongOne==wrongTwo)||(wrongOne==wrongThree)||(wrongTwo==wrongThree)|| (wrongOne == sum)|| (wrongTwo == sum)|| (wrongThree == sum))
                    {
                wrongOne = r1.Next(lower, upper);
                wrongTwo = r1.Next(lower, upper);
                wrongThree = r1.Next(lower, upper);
                n = r1.Next(lower, upper);
            }


            
           
            if (n<sum)
            {
                sum = sum ^ wrongOne;
                wrongOne = sum ^ wrongOne;
                sum = sum ^ wrongOne;
            }
            if (n==sum)
            {
                sum = sum ^ wrongTwo;
                wrongTwo = sum ^ wrongTwo;
                sum = sum ^ wrongTwo;
            }
            if (n > sum)
            {
                sum = sum ^ wrongThree;
                wrongThree = sum ^ wrongThree;
                sum = sum ^ wrongThree;
            }

            
        }
        public String toString()
        {
            string questionString = string.Format("{0} + {1} = {2},{3},{4},{5}",firstOperand,secondOperand,sum,wrongOne,wrongTwo,wrongThree);
            return questionString;
        }
        

    }
    class Program
    {
        static void Main(string[] args)
        {
            Question Fq = new Question(0, 10);
            Question Sq = new Question(10, 20);
            Question Tq = new Question(20, 30);
            Console.WriteLine(Fq.toString());
            Console.WriteLine(Sq.toString());
            Console.WriteLine(Tq.toString());

        }
    }
}
