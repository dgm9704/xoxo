﻿//
//  ScenarioTests.cs
//
//  Author:
//       John Nordberg <john.nordberg@gmail.com>
//
//  Copyright (c) 2015-2017 John Nordberg
//
//  Free Public License 1.0.0
//  Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted.
//  THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES 
//  OF MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES 
//  OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS 
//  ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

namespace Diwen.Xbrl.Tests
{
	using System;
	using System.IO;
	using NUnit.Framework;
	using Xbrl;

	[TestFixture]
	public static class ScenarioTests
	{
		[Test]
		public static void CompareScenarioMemberOrderDifferent()
		{
			var left = Instance.FromFile(Path.Combine(TestContext.CurrentContext.TestDirectory, "data", "memberorder0.xbrl"));
			var right = Instance.FromFile(Path.Combine(TestContext.CurrentContext.TestDirectory, "data", "memberorder1.xbrl"));

			Assert.AreEqual(left, right);

			var report = InstanceComparer.Report(left, right);

			Assert.IsTrue(report.Result, string.Join(Environment.NewLine, report.Messages));

		}
	}
}