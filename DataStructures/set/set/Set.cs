using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set
{
    public class Set<TypeElement>
    {
        private List<TypeElement> elements;

        /// <summary>
        ///  default constructor
        /// </summary>
        public Set()
        {
            this.elements = new List<TypeElement>();
        }

        /// <summary>
        /// constructor with parameter
        /// </summary>
        /// <param name="someElements">list of elements</param>
        public Set(List<TypeElement> someElements)
        {
            this.elements = new List<TypeElement>(someElements);
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="someSet">some set</param>
        public Set(Set<TypeElement> someSet)
        {
            this.elements = new List<TypeElement>(someSet.elements);
        }

        /// <summary>
        /// find element in set
        /// </summary>
        /// <param name="element">element for search</param>
        /// <returns>true if element was found, otherwise false</returns>
        public bool FindElement(TypeElement element)
        {
            if (this.elements.IndexOf(element) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// add element to set
        /// </summary>
        /// <param name="element">element for addition</param>
        /// <returns>true if element was added, otherwise false</returns>
        public bool AddElement(TypeElement element)
        {
            if (!this.FindElement(element))
            {
                this.elements.Add(element);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// remove element from set
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>true if element was removed, otherwise false</returns>
        public bool RemoveElement(TypeElement element)
        {
            return this.elements.Remove(element);
        }

        /// <summary>
        /// unites basic set with some set
        /// </summary>
        /// <param name="someSet"></param>
        public Set<TypeElement> UnionWithSet(Set<TypeElement> someSet)
        {
            Set<TypeElement> resultUnion = new Set<TypeElement>(this);
            foreach (var element in someSet.elements)
            {
                resultUnion.AddElement(element);
            }
            return resultUnion;
        }

        /// <summary>
        /// intersect basic set with some set
        /// </summary>
        /// <param name="someSet">some set</param>
        public Set<TypeElement> IntersectionWithSet(Set<TypeElement> someSet)
        {
            Set<TypeElement> resultIntersection = new Set<TypeElement>();
            foreach (var element in this.elements)
            {
                if (someSet.FindElement(element))
                {
                    resultIntersection.AddElement(element);
                }
            }
            return resultIntersection;
        }

        /// <summary>
        /// performs difference basic set with some set
        /// </summary>
        /// <param name="someSet">some set</param>
        public Set<TypeElement> DifferenceWithSet(Set<TypeElement> someSet)
        {
            Set<TypeElement> resultDifference = new Set<TypeElement>(this);
            foreach (var element in someSet.elements)
            {
                if (resultDifference.FindElement(element))
                {
                    resultDifference.RemoveElement(element);
                }
            }
            return resultDifference;
        }

        /// <summary>
        /// operator == of two sets
        /// </summary>
        /// <param name="firstSet">first set</param>
        /// <param name="secondSet">second set</param>
        /// <returns>true if sets are equel, false otherwise</returns>
        public static bool operator ==(Set<TypeElement> firstSet, Set<TypeElement> secondSet)
        {
            if (firstSet.elements.Count != secondSet.elements.Count)
            {
                return false;
            }
            foreach (var element in firstSet.elements)
            {
                if (!secondSet.FindElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// operator != of two sets
        /// </summary>
        /// <param name="firstSet">first set</param>
        /// <param name="secondSet">second set</param>
        /// <returns>true if sets aren`t equel, false otherwise/returns>
        public static bool operator !=(Set<TypeElement> firstSet, Set<TypeElement> secondSet)
        {
            return !(firstSet == secondSet);
        }
    }
}
