﻿namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface IFromBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The Where Method
        /// 
        /// Use this method to add a where expression 
        /// </summary>
        /// <example>
        /// This sample shows how to call the Where method.
        /// <code>
        /// builder.Where("Name LIKE '%abc%'");
        /// </code>
        /// </example>
        /// <param name="where">String representation of the where expression</param>
        IWhereBuilder Where(string where);
        /// <summary>
        /// The Where Method
        /// </summary>
        /// <example>
        /// This example shows how to call the where method
        /// <code>
        /// builder.Where("Name", "john");
        /// </code>
        /// </example>
        /// <param name="field">Field to be compared</param>
        /// <param name="value">Value the field should equal</param>
        IWhereBuilder Where(string field, object value);
        /// <summary>
        /// The Inner Join Method
        /// 
        /// Use this method to inner join a table to the initial FROM
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").InnerJoin("otherTable").On("a = b");
        /// </code>
        /// </example>
        /// <param name="joiningTable">Table to be joined</param>
        IJoinBuilder InnerJoin(string joiningTable);


        /// <summary>
        /// The Right Join Method
        /// 
        /// Use this method to right join a table to the initial FROM
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").RightJoin("otherTable").On("a = b");
        /// </code>
        /// </example>
        /// <param name="joiningTable">Table to be joined</param>
        IJoinBuilder RightJoin(string joiningTable);

        /// <summary>
        /// The Left Join Method
        /// 
        /// Use this method to Left join a table to the initial FROM
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").LeftJoin("otherTable").On("a = b");
        /// </code>
        /// </example>
        /// <param name="joiningTable">Table to be joined</param>
        IJoinBuilder LeftJoin(string joiningTable);
        /// <summary>
        /// The OrderBy Method
        /// 
        /// Use this method to apply a field to order the query by
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").OrderBy("a");
        /// </code>
        /// </example>
        /// <param name="field"></param>
        IOrderByBuilder OrderBy(string field);
        /// <summary>
        /// The Paginate Method
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").Paginate(4, 20);
        /// </code>
        /// </example>
        /// <param name="pageNumber">integer of the page number to retrieve</param>
        /// <param name="pageSize">integer of the page size</param>
        /// <returns></returns>
        ISqlQueryBuilder Paginate(int pageNumber, int pageSize);
    }
}