namespace ObjectsComparer
{
    public class Comparer
    {
        private bool CompareObjectsInternally(object objOne, object objTwo)
        {
            if (ReferenceEquals(objOne, objTwo))
                return true;

            if (objOne == null || objTwo == null)
                return false;

            if (!objOne.GetType().Equals(objTwo.GetType()))
                return false;

            bool matched = true;
            if(!objOne.GetType().IsValueType)
            foreach(var property in objOne.GetType().GetProperties())
            {
                var propOne = property.GetValue(objOne);
                var propTwo = property.GetValue(objTwo);                

                if (!propOne.Equals(propTwo))
                    matched = false;
            }
            else
            {
                return objOne.Equals(objTwo);
            }
            return matched;
        }

        public bool CompareObjects(object objOne, object objTwo)
        {
            bool matched = true;
            if (ReferenceEquals(objOne, objTwo))
                return true;

            else if (objOne == null || objTwo == null)
                return false;

            else if (!objOne.GetType().Equals(objTwo.GetType()))
                return false;

            else if (!objOne.GetType().IsClass)
                return objOne.Equals(objTwo);

            else
                foreach (var property in objOne.GetType().GetProperties())
                {
                    var propOne = property.GetValue(objOne);
                    var propTwo = property.GetValue(objTwo);

                    if (CompareObjectsInternally(propOne,propTwo)==false)
                        matched = false;
                }
            return matched;
        }
    }

}
