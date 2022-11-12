namespace SCscCL_Model
{
    public class ComplexObject
    {
        private const decimal decimalVar1 = 65_000;
        private const decimal decimalVar2 = 25_000;
        private const int intVar1 = 25000;
        public string result;

        private readonly SimpleObject1 simpleObject1;
        private readonly SimpleObject2 simpleObject2;

        public ComplexObject(SimpleObject1 simpleObject1, SimpleObject2 simpleObject2)
        {
            this.simpleObject1 = simpleObject1 ?? throw new ArgumentNullException(nameof(simpleObject1));
            this.simpleObject2 = simpleObject2 ?? throw new ArgumentNullException(nameof(simpleObject2));
        }

        public void ProcessStart()
        {
            if (simpleObject1 != null && simpleObject2 != null)
            {
                ProcessEnd();
            }
        }

        public void ProcessEnd()
        {
            result = nameof(ProcessEnd);
        }
    }
}