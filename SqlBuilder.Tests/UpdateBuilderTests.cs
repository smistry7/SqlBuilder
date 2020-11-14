﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BeeseChurger.SqlBuilder.Misc;
using AutoFixture.Xunit2;

namespace BeeseChurger.SqlBuilder.Tests
{
    public class UpdateBuilderTests
    {
        [Fact]
        public void ShouldBuildUpdateQuery()
        {
            var dateTime = DateTime.Now;
            var builder = UpdateBuilder
                .Update("dbo.table")
                .Set("company", "dummyCompany")
                .Set("LastUpdatedDate", dateTime)
                .Where("id", 5)
                .And("foreignId LIKE 'AB15'");
            builder.Build().Should()
                .Be($"UPDATE dbo.table SET company = 'dummyCompany', " +
                $"LastUpdatedDate = {dateTime.ToSqlParameter()} WHERE id = 5 AND foreignId LIKE 'AB15' ;");
        }
    }
}
