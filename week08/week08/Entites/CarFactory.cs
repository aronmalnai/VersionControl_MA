using week08.Abstractions;


namespace week08.Entites
{
    class CarFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            Car c = new Car();
            return c;
        
        }

       
    }
}
