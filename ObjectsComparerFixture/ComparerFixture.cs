using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ObjectsComparer;

namespace ObjectsComparerFixture
{

    public partial class ComparerFixture
    {
        private Comparer _comparer;
        public ComparerFixture()
        {
            _comparer = new Comparer();
        }

        [Fact]
        public void Two_objects_having_same_refernce_should_return_true()
        {
            Mammal human1 = new Mammal();
            Mammal human2 = human1;
            Assert.True(_comparer.CompareObjects(human1, human2));
        }

        [Fact]
        public void Any_objects_having_null_refernce_should_return_false()
        {
            Mammal human1 = new Mammal();
            Mammal human2 = null;
            Assert.False(_comparer.CompareObjects(human1, human2));
        }

        [Fact]
        public void Objects_of_different_types_should_return_false()
        {
            Mammal human = new Mammal();
            var animal = new { };
            Assert.False(_comparer.CompareObjects(human, animal));
        }

        [Fact]
        public void Objects_of_not_class_type_should_return_matched_value()
        {
            int num1 = 10;
            int num2 = 50;
            int num3 = 50;
            Assert.False(_comparer.CompareObjects(num1, num2));
            Assert.True(_comparer.CompareObjects(num2, num3));
        }

        [Fact]
        public void Objects_having_same_type_and_properties_value_should_matched_value()
        {
            Mammal human1 = new Mammal();
            human1.Age = 20;
            Mammal human2 = new Mammal();
            human2.Age = 20;
            Mammal human3 = new Mammal();
            human3.Age = 30;
            Assert.True(_comparer.CompareObjects(human1, human2));
            Assert.False(_comparer.CompareObjects(human2, human3));
        }

        //Object chaining
        public void Objects_having_properties_of_any_other_object_type_should_return_matched_value()
        {
            Mammal human = new Mammal();
            Mammal bird = new Mammal();

            Animalia animal1 = new Animalia();
            animal1.Type = human;
            Animalia animal2 = new Animalia();
            animal2.Type = human;
            Animalia animal3 = new Animalia();
            animal3.Type = bird;

            Assert.True(_comparer.CompareObjects(animal1,animal2));
            Assert.False(_comparer.CompareObjects(animal2, animal3));
        }
    }
}
