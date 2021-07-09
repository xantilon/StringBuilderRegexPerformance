using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringBuilderRegexPerformance.Tests
{
    [TestClass()]
    public class StringReplaceTests
    {
        [TestMethod()]
        public void TestStringShouldUseful()
        {
            var sut = new StringReplace();
            sut.TestText.Should().Contain("<u>")
                .And.Contain("<b>")
                .And.Contain("<br />")
                .And.Contain("<br/>")
                .And.Contain("<br>")
                .And.Contain("</u>")
                .And.Contain("</b>")
                .And.Contain("<BR />");                
        }

        [TestMethod()]
        public void ResultsShouldBeDifferent()
        {
            var sut = new StringReplace();
            var r1 = sut.WithString();
            var r2 = sut.WithStringBuilder();
            var r3 = sut.WithRegex();
            sut.TestText.Should().NotBeEquivalentTo(r1)
                .And.NotBeEquivalentTo(r2)
                .And.NotBeEquivalentTo(r3);
        }

        [TestMethod()]
        public void StringAndStringBuilderShouldBeEqualTest()
        {
            var sut = new StringReplace();
            var r1 = sut.WithString();
            var r2 = sut.WithStringBuilder();
            r1.Should().BeEquivalentTo(r2);
        }
        
        [TestMethod()]
        public void StringAndRegexShouldBeEqualTest()
        {
            var sut = new StringReplace();
            var r1 = sut.WithString();
            var r2 = sut.WithRegex();
            r1.Should().BeEquivalentTo(r2);
        }

        [TestMethod()]
        public void WithStringShouldRemoveAllTags()
        {
            var sut = new StringReplace();
            var r1 = sut.WithString();

            r1.Should().NotContain("<u>")
            .And.NotContain("<b>")
            .And.NotContain("<br />")
            .And.NotContain("<u/>")
            .And.NotContain("<b/>")
            .And.NotContain("<BR />");
        }

        [TestMethod()]
        public void WithStringBuilderShouldRemoveAllTags()
        {
            var sut = new StringReplace();
            var r1 = sut.WithStringBuilder();

            r1.Should().NotContainAny("<u>");
            r1.Should().NotContain("<b>");
            r1.Should().NotContain("<br />");

            r1.Should().NotContain("<u/>");
            r1.Should().NotContain("<b/>");
            r1.Should().NotContain("<BR />");
        }
    }
}