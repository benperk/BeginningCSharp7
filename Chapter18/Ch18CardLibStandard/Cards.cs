using System.Collections.Generic;

namespace Ch18CardLibStandard
{
    /// <summary>
    /// Class for handling the Cards in a Deck
    /// </summary>
    public class Cards : List<Card>
    {
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
    }
}
