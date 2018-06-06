
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace bcNewLineSpec
{
    public partial class MainForm : Form
    {
        string newEqTextBoxPlaceHolder = "Enter new EQ here...";
        public static Excel.Application SrcExcelApp { get; set; } = null;
        public static Workbook SrcWorkBook { get; set; } = null;
        public static string ExeDir { get; set; } = null;

        public class BcEvent
        {
            public int WorkSheetInd { get; set; } = -1;
            public string EventName { get; set; } = null;
            public Range EventRnage { get; set; } = null;

            public BcEvent(int workSheetInd, string eventName, Range eventRange)
            {
                this.WorkSheetInd = workSheetInd;
                this.EventName = eventName;
                this.EventRnage = eventRange;
            }
            public int GetEventLength()
            {
                int firstRowInd = GetRangeRowInd(this.EventRnage, true);
                int lastRowInd = GetRangeRowInd(this.EventRnage);
                return lastRowInd - firstRowInd;
            }
            override
            public string ToString()
            {
                return $"{this.EventName}";
            }
        }
        public class EqBcEvent
        {
            public int EqIndex { get; set; } = -1;
            public string EqName { get; set; } = null;
            public BcEvent _BcEvent { get; set; } = null;

            public EqBcEvent(int eqIndex, string eqName, BcEvent bcEvent)
            {
                this.EqIndex = eqIndex;
                this.EqName = eqName;
                this._BcEvent = bcEvent;
            }
            override
            public string ToString()
            {
                return $"{this.EqIndex:D2} {this.EqName} [{this._BcEvent.ToString()} ({this._BcEvent.GetEventLength()}Word)]";
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // newEqTextBox
            NewEqTextBox.Text = newEqTextBoxPlaceHolder;
            NewEqTextBox.GotFocus += RemoveText;
            NewEqTextBox.LostFocus += AddText;

            // eqListBox
            eqListBox.Items.Add("Master PLC");

            // open and load source excel file
            MainForm.SrcExcelApp = new Excel.Application();
            MainForm.SrcExcelApp.Visible = true;
            string exePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            MainForm.ExeDir = System.IO.Path.GetDirectoryName(exePath);
            MainForm.SrcWorkBook = MainForm.SrcExcelApp.Workbooks.Open(MainForm.ExeDir +
                    "\\test.xls");
                    //"\\InnoLux_T2_IOMapping_SummaryV2.xls");

            // debug use ###
            //Worksheet Ws = MainForm.SrcWorkBook.Worksheets[1];
            //Ws.Range["A6:A10"].Rows.Group();
            //Ws.Outline.SummaryRow = Microsoft.Office.Interop.Excel.XlSummaryRow.xlSummaryAbove;


            List<BcEvent> allBcEventList = new List<BcEvent>();
            ParseWorkSheet(MainForm.SrcWorkBook, allBcEventList);

            

            // eventList
            foreach (var aBcEvent in allBcEventList)
            {
                EventCheckListBox.Items.Add(aBcEvent);
            }
            
        }

        
        public static int GetRangeRowInd(Range aRange, Boolean reverse = false)
        {
            string rangeAddress = aRange.Address;
            if (!reverse)
            {
                string lastRowIndStr = rangeAddress.Substring(rangeAddress.LastIndexOf("$") + 1);
                return int.Parse(lastRowIndStr);
            }

            int startInd = rangeAddress.IndexOf("$", 1) + 1;
            int endInd = rangeAddress.IndexOf(":");

            string firstRowInd = rangeAddress.Substring(startInd, endInd - startInd);
            return int.Parse(firstRowInd);
        }

        public void ParseWorkSheet(Workbook srcWorkBook, List<BcEvent> allBcEventList)
        {
            for (int workSheetInd = 1; workSheetInd <= srcWorkBook.Worksheets.Count; workSheetInd++)
            {
                Worksheet aWorkSheet = srcWorkBook.Worksheets[workSheetInd];
                int maxRowInd = GetRangeRowInd(aWorkSheet.UsedRange);
                for (int startRowInd = 2; startRowInd < maxRowInd; startRowInd++)
                {
                    string cellValue = aWorkSheet.Cells[startRowInd, 1].Value2?.ToString();
                    if (cellValue == null) continue;

                    int endRowInd = startRowInd + 1;
                    do
                    {
                        string endCellValue = aWorkSheet.Cells[endRowInd, 2].Value2?.ToString();
                        if (endCellValue == null) break;
                        if (aWorkSheet.Cells[endRowInd, 2].MergeCells)
                        {
                            endRowInd = GetRangeRowInd(aWorkSheet.Cells[endRowInd, 2].MergeArea) + 1;
                        }
                        else
                        {
                            endRowInd++;
                        }
                    } while (true);

                    Range eventRange = aWorkSheet.Range[aWorkSheet.Cells[startRowInd, 1], aWorkSheet.Cells[endRowInd - 1, 7]];
                    allBcEventList.Add(new BcEvent(workSheetInd, cellValue, eventRange));
                    startRowInd = endRowInd;
                }
            }
        }
        public void RemoveText(object sender, EventArgs e)
        {
            NewEqTextBox.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NewEqTextBox.Text))
                NewEqTextBox.Text = newEqTextBoxPlaceHolder;
        }


        private void AddEqButton_Click(object sender, EventArgs e)
        {
            eqListBox.Items.Add($"{NewEqTextBox.Text}");
        }

        private void DelEqButton_Click(object sender, EventArgs e)
        {
            if (eqListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select EQ in eqList first", "Warning", MessageBoxButtons.OK);
                return;
            }
            eqListBox.Items.RemoveAt(eqListBox.SelectedIndex);
        }

        public void BuildBorder(Range aRange)
        {
            Microsoft.Office.Interop.Excel.Borders border = aRange.Borders;
            border[XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }


        private void ProduceBtn_Click(object sender, EventArgs e)
        {
            // open destination excel file
            var destworkBook = MainForm.SrcExcelApp.Workbooks.Add();
            var destworkSheet = destworkBook.Worksheets.get_Item(1);

            // copy 
            int rowInd = 1;
            foreach(EqBcEvent aEqBcEvent in SelectedListBox.Items)
            {
                // frist line
                Range firstLineFirstCell = destworkSheet.Cells[rowInd, 1];
                firstLineFirstCell.Value2 = aEqBcEvent.ToString(); // event Name
                firstLineFirstCell.Font.Bold = true;
                Range firstLine = destworkSheet.Range[destworkSheet.Cells[rowInd, 1], destworkSheet.Cells[rowInd, 8]];
                firstLine.Interior.Color = System.Drawing.Color.MediumOrchid;
                BuildBorder(firstLine);
                
                rowInd++;

                // get original range position
                Excel.Range from = aEqBcEvent._BcEvent.EventRnage;
                int rangeLastRowInd = GetRangeRowInd(from);
                int rangeStartRowInd = GetRangeRowInd(from, true);

                // copy value and format
                Worksheet oriWs = MainForm.SrcWorkBook.Worksheets[aEqBcEvent._BcEvent.WorkSheetInd];
                // cut the first line, which is original event name
                // first argument is relative to absolute cells(A1), second argument is decide the range size
                Range cutFirstLineFrom = from.Range[oriWs.Cells[2, 2], 
                                                    oriWs.Cells[2 + rangeLastRowInd - rangeStartRowInd - 1, 7]]; 
                int toLastRowInd = rowInd + rangeLastRowInd - rangeStartRowInd - 1;
                Excel.Range to = destworkSheet.Range[destworkSheet.Cells[rowInd, 3],
                                                     destworkSheet.Cells[toLastRowInd, 9]];
                cutFirstLineFrom.Copy();
                to.PasteSpecial(XlPasteType.xlPasteAllUsingSourceTheme);
                to.PasteSpecial(XlPasteType.xlPasteColumnWidths);
                to.Rows.Group();

                // add formula on first and second column of range
                for(int formulaRowInd = rowInd; formulaRowInd <= toLastRowInd; formulaRowInd++)
                {
                    destworkSheet.Cells[formulaRowInd, 1].Formula = $"=RIGHT(B{formulaRowInd}, 5)";
                    destworkSheet.Cells[formulaRowInd, 2].Formula = $"=IF(B{formulaRowInd - 1}<>\"\", \n" + 
                            $"\"LW\" & RIGHT(\"0000\" & DEC2HEX(HEX2DEC(RIGHT({formulaRowInd - 1}, 4)) + 1), 4), \n" +
                            $"\"LW\" & RIGHT(\"0000\" & DEC2HEX(HEX2DEC(RIGHT(B{formulaRowInd - 2}, 4)) + 1), 4))";
                    BuildBorder(destworkSheet.Cells[formulaRowInd, 1]);
                    BuildBorder(destworkSheet.Cells[formulaRowInd, 2]);
                }

                rowInd = toLastRowInd + 1;
            }
            destworkSheet.Cells[2, 1].Value = "L0000";
            destworkSheet.Cells[2, 2].Value = "LW0000";
            destworkBook.SaveAs( $"{MainForm.ExeDir}\\{DateTime.Now.ToString("yyyyMMddHHmm")}output.xls");

            // close destination excel file
            MainForm.SrcExcelApp.Application.DisplayAlerts = false;
            MainForm.SrcExcelApp.Quit();

            MessageBox.Show("Action finished", "Info", MessageBoxButtons.OK);
            return;
        }

        private void EventCheckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            if (eqListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select EQ in eqList first", "Warning", MessageBoxButtons.OK);
                return;
            }

            foreach (var selectedItem in EventCheckListBox.CheckedItems)
            {
                EqBcEvent aEqBcEvent = new EqBcEvent(eqListBox.SelectedIndex + 1, eqListBox.SelectedItem.ToString(), (BcEvent)selectedItem);
                SelectedListBox.Items.Add(aEqBcEvent);
                SelectedListBox.Sorted = true;
            }
        }
    }
}
