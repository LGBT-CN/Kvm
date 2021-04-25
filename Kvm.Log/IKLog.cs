namespace Kvm.Log
{
    public interface IKLog
    {
        public void W(string msg);
        public void I(string msg);
        public void E(string msg);
        public void S(string msg);
    }
}