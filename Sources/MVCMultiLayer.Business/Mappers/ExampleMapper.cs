using MVCMultiLayer.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCMultiLayer.Business.Mappers
{
    public static class ExampleMapper
    {
        /// <summary>
        /// Maps a list of DAL.Example to a list of Business.Example
        /// </summary>
        /// <param name="listSource"></param>        
        /// <returns></returns>
        public static List<Example> Map(this List<DAL.Entities.Example> listSource)
        {
            var rtn = new List<Example>();

            if (listSource != null && listSource.Any())
                listSource.ForEach(x => rtn.Add(x.Map()));

            return rtn;
        }

        /// <summary>
        /// Maps a IQueryable of DAL.Example to a list of Business.Example
        /// </summary>
        /// <param name="listSource"></param>        
        /// <returns></returns>
        public static List<Example> MapIQueryable(this IQueryable<DAL.Entities.Example> listSource)
        {
            var rtn = new List<Example>();

            if (listSource != null && listSource.Any())
                rtn = listSource.Select(source => new Example()
                {
                    ID = source.ID,
                    MyIntegerProperty = source.MyIntegerProperty,
                    MyStringProperty = source.MyStringProperty,
                    MyNullableProperty = source.MyNullableProperty,
                    DateCreation = source.DateCreation,
                    UserCreation = source.UserCreation,
                    DateLastChange = source.DateLastChange,
                    UserLastChange = source.UserLastChange
                }).ToList();

            return rtn;
        }

        /// <summary>
        /// Maps a DAL.Example to Business.Example
        /// </summary>
        /// <param name="source"></param>        
        /// <returns></returns>
        public static Example Map(this DAL.Entities.Example source)
        {
            if (source != null)
                return new Example()
                {
                    ID = source.ID,
                    MyIntegerProperty = source.MyIntegerProperty,
                    MyStringProperty = source.MyStringProperty,
                    MyNullableProperty = source.MyNullableProperty,
                    DateCreation = source.DateCreation,
                    UserCreation = source.UserCreation,
                    DateLastChange = source.DateLastChange,
                    UserLastChange = source.UserLastChange
                };
            else
                return null;
        }

        /// <summary>
        /// Maps a DAL.Example to Business.Example
        /// </summary>
        /// <param name="source"></param>       
        /// <returns></returns>
        public static DAL.Entities.Example MapInverse(this Example source)
        {
            if (source != null)
                return new DAL.Entities.Example()
                {
                    ID = source.ID,
                    MyIntegerProperty = source.MyIntegerProperty,
                    MyStringProperty = source.MyStringProperty,
                    MyNullableProperty = source.MyNullableProperty,
                    DateCreation = source.DateCreation,
                    UserCreation = source.UserCreation,
                    DateLastChange = source.DateLastChange,
                    UserLastChange = source.UserLastChange,
                };
            else
                return null;
        }

        /// <summary>
        /// Maps a DAL.Example to Business.Example maintaining some original values passed in "rtn" parameter
        /// </summary>
        /// <param name="source"></param>
        /// <param name="rtn"></param>
        /// <returns></returns>
        public static DAL.Entities.Example MapInverse(this Example source, DAL.Entities.Example rtn)
        {
            if (source != null && rtn != null)
            {
                rtn.ID = source.ID;
                rtn.MyIntegerProperty = source.MyIntegerProperty;
                rtn.MyStringProperty = source.MyStringProperty;
                rtn.MyNullableProperty = source.MyNullableProperty;
                rtn.DateCreation = source.DateCreation;
                rtn.UserCreation = source.UserCreation;
                rtn.DateLastChange = source.DateLastChange;
                rtn.UserLastChange = source.UserLastChange;

                return rtn;
            }
            else
                return null;
        }
    }
}
