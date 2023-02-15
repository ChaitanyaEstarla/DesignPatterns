namespace FactoryPattern
{
    public abstract class ACreator
    {
        protected abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Blaze: " + product.Operation();
            return result;
        }
    }
}
