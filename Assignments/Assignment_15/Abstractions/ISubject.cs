using Assignment_15.Enums;

namespace Assignment_15.Abstractions
{
    public interface ISubject
    {
        public void Subscribe(IObserver observer);
        public void Unsubcribe(IObserver observer);    
    }
}
