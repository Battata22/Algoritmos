public interface ITargetable 
{
    void Suscribe(IObserver x);

    void Unsuscribe(IObserver x);
}
