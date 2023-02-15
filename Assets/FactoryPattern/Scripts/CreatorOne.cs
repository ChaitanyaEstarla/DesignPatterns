namespace FactoryPattern
{
    public class CreatorOne : ACreator
    {
        protected override IProduct FactoryMethod()
        {
            return new ProductOne();
        }
    }
}
