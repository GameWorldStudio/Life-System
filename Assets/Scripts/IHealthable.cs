public interface IHealthable
{
    int HealthPoint { get; set; }
    int ShieldhPoint { get; set; }

    void TakeHealth(HealthData healthAttributs);

}
