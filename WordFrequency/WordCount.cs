namespace WordFrequency
{
    public class WordCount
    {
        private string word;
        private int count;

        public WordCount(string w, int i)
        {
            this.word = w;
            this.count = i;
        }

        public string Word
        {
            get { return this.word; }
        }

        public int Count
        {
            get { return this.count; }
        }
    }
}
