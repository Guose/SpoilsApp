using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoils.BLL
{
    public class SequenceNumbers : SpoilsHandler, ISequence
    {
        #region Constructors
        public SequenceNumbers()
        {

        }
        public SequenceNumbers(long firstNum, long lastNum) : base(firstNum, lastNum)
        {
            
        }
        #endregion Constructor


        #region Properties

        public bool DoMainBreak { get; set; }

        #endregion Properties

        /// <summary>
        /// Used for breaking out of loops when retrieving 
        /// records from a data source
        /// </summary>
        /// <returns>returns true when numbers are equal and breaks loop</returns>
        public bool CheckNumbersAreEqual()
        {
            if (FirstNumber == LastNumber)
                DoMainBreak = true;

            return DoMainBreak;            
        }
    }
}
