﻿using System;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace CodeContracts.Specs
{
    public class RequiresSpecs
    {
        //todo: cover other methods
        
        [TestFixture]
        public class when_requires_that_good_object_is_not_null
        {
            [Test]            
            public void should_not_throw()
            {
                Requires.NotNull("test", "param");                  
            }
        }

        [TestFixture]
        public class when_requires_that_null_object_is_not_null
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void should_throw()
            {
                Requires.NotNull<string>(null, "param");
            }
        }

        [TestFixture]
        public class when_requires_that_good_string_is_not_null_or_empty
        {
            [Test]
            public void should_not_throw()
            {
                Requires.NotNullOrEmpty("test", "param");
            }
        }
        
        [TestFixture]
        public class when_requires_that_null_or_empty_string_is_not_null_or_empty
        {
            [TestCase(null, typeof(ArgumentNullException))]
            [TestCase("",typeof(ArgumentException))]            
            public void should_throw(string str, Type targetException)
            {
                Assert.Throws(targetException, () => Requires.NotNullOrEmpty(str, "param"));
            }
        }

        [TestFixture]
        public class when_requires_that_null_string_length_is_greater_than
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void should_throw()
            {
                Requires.LengthGreaterThan(null, 3, "param");
            }
        }
        
        [TestFixture]
        public class when_requires_that_good_string_length_is_greater_than
        {
            [Test]
            public void should_not_throw()
            {
                Requires.LengthGreaterThan("test", 3, "param");
            }
        }

        [TestFixture]
        public class when_requires_that_short_string_length_is_greater_than
        {
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void should_throw()
            {
                Requires.LengthGreaterThan("test", 5, "param");
            }
        }

        [TestFixture]
        public class when_requires_that_null_string_length_is_greater_or_equal_than
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void should_throw()
            {
                Requires.LengthGreaterOrEqual(null, 3, "param");
            }
        }

        [TestFixture]
        public class when_requires_that_good_string_length_is_greater_or_equal_than
        {
            [Test]
            public void should_not_throw()
            {
                Requires.LengthGreaterOrEqual("test", 4, "param");
            }
        }

        [TestFixture]
        public class when_requires_that_short_string_length_is_greater_or_equal_than
        {
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void should_throw()
            {
                Requires.LengthGreaterOrEqual("test", 5, "param");
            }
        }

        [TestFixture]
        public class when_requires_that_in_range_when_condition_is_false
        {
            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void should_throw()
            {
                Requires.InRange(false, "par");
            }
        }

        [TestFixture]
        public class when_requires_that_in_range_when_condition_is_true
        {
            [Test]            
            public void should_not_throw()
            {
                Requires.InRange(true, "par");
            }
        }

        [TestFixture]
        public class when_requires_that_condition_is_true_providing_false_value
        {
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void should_throw()
            {
                Requires.True(false, "par", "message");
            }
        }

        [TestFixture]
        public class when_requires_that_condition_is_true_providing_true_value
        {
            [Test]
            public void should_not_throw()
            {
                Requires.True(true, "par", "message");
            }
        }
        
        [TestFixture]
        public class when_requires_that_condition_is_true_providing_false_value2
        {
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void should_throw()
            {
                Requires.True(false, "par");
            }
        }

        [TestFixture]
        public class when_requires_that_condition_is_true_providing_true_value2
        {
            [Test]            
            public void should_not_throw()
            {
                Requires.True(true, "par");
            }
        }

	    [TestFixture]
	    public class when_requires_that_not_default_providing_default_value_type
	    {
		    [Test]
				[ExpectedException(typeof(ArgumentException))]
		    public void should_throw()
		    {
			    Requires.NotDefault(default(int), "value", "the parameter '{0}' is default when it should not be", "value");
		    }
	    }

	    [TestFixture]
	    public class when_requires_that_not_default_providing_default_reference_type
	    {
		    [Test]
		    [ExpectedException(typeof(ArgumentException))]
		    public void should_throw()
		    {
			    Requires.NotDefault(default(string), "value");
		    }
	    }

			[TestFixture]
	    public class when_requires_that_not_default_providing_nondefault_value_type
	    {
		    [Test]
		    public void should_not_throw()
		    {
			    Requires.NotDefault(1, "value");
		    }
	    }

	    [TestFixture]
	    public class when_requires_that_not_default_providing_nondefault_reference_type
	    {
		    [Test]
		    public void should_not_throw()
		    {
			    Requires.NotDefault("test", "value");
		    }
	    }
    }
}

// ReSharper restore InconsistentNaming