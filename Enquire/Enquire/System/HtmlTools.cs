using System;
using System.Collections.Specialized;
using System.Text;


namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for HtmlTools.
	/// </summary>
	public class HtmlTools
	{
		//private string document;
		private string style;
		private string title;

		private StringBuilder Document;

		public HtmlTools()
		{
			//document = String.Empty;
			Document = new StringBuilder(string.Empty);
		}

		public string GetDocument()
		{
			string data = String.Empty;

			data += "<html>";
			//header
			data += "<head>";
			data += "<title>" + title + "</title>";
			data += "<style>" + style + "</style>";
			data += "</head>";

			//document
			data += "<body>";
			data += Document.ToString();
			data += "</body>";


			data += "</html>";

			return data;
		}

		public void StartTable(string style, int padding, int spacing)
		{
			StartTable(style, padding, spacing, "none");
		}

		public void StartTable(string style, int padding, int spacing, string rules)
		{
			Line("<table rules='"+rules+"' class='"+style+"' cellspacing='"+spacing+"' cellpadding='"+padding+"'>");
		}

		public void EndTable()
		{
			Line("</table>");
		}

		public void SetTitle(string title)
		{
			this.title = title;
		}

		public void SetStyle(string style)
		{
			this.style = style;
		}

		public void Line(string html)
		{
			Document.Append(html + "\n");
			//document += html + "\n";
		}

		public void Paragraph(string html)
		{
			Document.Append("<p>" + html + "</p>\n");
			//document += "<p>" + html + "</p>\n";
		}

		public void DottedLine()
		{
			Document.Append("................................................................................................................................<br/>\n");
			//document += "................................................................................................................................<br/>\n";
		}

		public void Pagebreak()
		{
			Line("<div style='page-break-before:always'>&nbsp;</div>");
		}

		public void Header2(string header)
		{
			Line("<h2>" + header + "</h2>");
		}

		public void Header1(string header)
		{
			Line("<h1>" + header + "</h1>");
		}
	}
}
