Console.WriteLine("Hello, World!");
Cocinero Pedro = new Cocinero();
Pedro.EncenderCocina();

Task.Run(async () =>
{
    await Pedro.TostarPan();
    
});

Pedro.PrepararCafe();





public class Cocinero
{
    public void EncenderCocina()
    {
        Console.WriteLine("Enciende Horno");
    }
    public async Task<bool> TostarPan()
    {
        Console.WriteLine("Coloca pan en la Tostadora");
        Thread.Sleep(10000);
        Console.WriteLine("Saca el pan de la Tostadora");
        return true;
    }
    public void PrepararCafe()
    {
        Console.WriteLine("Calienta Agua");
        Thread.Sleep(15000);
        Console.WriteLine("Pone la Taza");
        Console.WriteLine("Agrega Azucar y Cafe");
        Console.WriteLine("Sirve el Agua");
    }
}