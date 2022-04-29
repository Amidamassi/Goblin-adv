using System.Collections.Generic;

namespace DefaultNamespace.Stats
{
    public class PassivesData
    {
        private List<Passives> _addedPassives;
        private List<Passives> _aviablePassives;

        public List<Passives> getAviablePassives()
        {
            return _aviablePassives;
        }
    }

    

}