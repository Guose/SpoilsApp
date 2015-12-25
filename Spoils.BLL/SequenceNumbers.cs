using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoils.BLL
{
    internal class SequenceNumbers : SpoilsHandler
    {
        #region Constructors
        public SequenceNumbers()
        {

        }

        public SequenceNumbers(long singleRec) : this()
        {
            this.SingleRecord = singleRec;
        }
        public SequenceNumbers(long firstNum, long lastNum) : this()
        {
            if (LastNumber <= FirstNumber)
            {
                this.FirstNumber = lastNum;
                this.LastNumber = firstNum;
            }
            else
            {
                this.FirstNumber = firstNum;
                this.LastNumber = lastNum;
            }
        }
        #endregion Constructor


        #region Properties

        public long SingleRecord { get; set; }


        private long firstNumber;

        public long FirstNumber
        {
            get { return firstNumber; }
            set { firstNumber = value; }
        }
        private long lastNumber;

        public long LastNumber
        {
            get { return lastNumber; }
            set { lastNumber = value; }
        }

        private bool doMainBreak;

        public bool DoMainBreak
        {
            get { return doMainBreak; }
            set { doMainBreak = value; }
        }
        #endregion Properties


        /// <summary>
        /// Used for breaking out of loops when retrieving 
        /// records from a data source
        /// </summary>
        /// <returns>returns true when numbers are equal</returns>
        public bool CheckNumbersAreEqual()
        {
            while (FirstNumber <= LastNumber)
            {
                if (FirstNumber == LastNumber)
                {
                    DoMainBreak = true;
                    break;                  
                }
                FirstNumber++;

            }
            return DoMainBreak;
            
        }
    }
}
