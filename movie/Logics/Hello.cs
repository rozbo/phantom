using movie.Interfaces;

namespace movie.Logics
{
    public class Hello : IHello
    {
        private int times = 0;
        public string Say()
        {
            this.times++;
            return "lalala:"+times.ToString();
        }
    }
}