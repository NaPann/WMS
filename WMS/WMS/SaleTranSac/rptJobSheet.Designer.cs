namespace WMS.SaleTranSac
{
    partial class rptJobSheet
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptJobSheet));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.JobSheet = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroup = new Telerik.Reporting.Group();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.prdONumberDataTextBox = new Telerik.Reporting.TextBox();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.prdQuantityDataTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.materialCodeDataTextBox = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.componentCodeDataTextBox = new Telerik.Reporting.TextBox();
            this.cLocCodeDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // JobSheet
            // 
            this.JobSheet.ConnectionString = "Data Source=.\\SQLEXPRESS2008;Initial Catalog=MRP_TEST;Persist Security Info=True;" +
                "User ID=sa;Password=Thannp@5843";
            this.JobSheet.Name = "JobSheet";
            this.JobSheet.ProviderName = "System.Data.SqlClient";
            this.JobSheet.SelectCommand = resources.GetString("JobSheet.SelectCommand");
            // 
            // labelsGroupHeader
            // 
            this.labelsGroupHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0099999997764825821);
            this.labelsGroupHeader.Name = "labelsGroupHeader";
            this.labelsGroupHeader.PrintOnEveryPage = true;
            // 
            // labelsGroupFooter
            // 
            this.labelsGroupFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0099999997764825821);
            this.labelsGroupFooter.Name = "labelsGroupFooter";
            this.labelsGroupFooter.Style.Visible = false;
            // 
            // labelsGroup
            // 
            this.labelsGroup.GroupFooter = this.labelsGroupFooter;
            this.labelsGroup.GroupHeader = this.labelsGroupHeader;
            this.labelsGroup.Name = "labelsGroup";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699);
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5865650177001953), Telerik.Reporting.Drawing.Unit.Inch(0.479412704706192));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8504918813705444), Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923));
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14);
            this.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "ใบสั่งงานการผลิต";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.10003940016031265), Telerik.Reporting.Drawing.Unit.Inch(1.0656331777572632));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67496061325073242), Telerik.Reporting.Drawing.Unit.Inch(0.22083334624767304));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox2.StyleName = "PageInfo";
            this.textBox2.Value = "รหัสสินค้า :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0354337692260742), Telerik.Reporting.Drawing.Unit.Inch(0.71974968910217285));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.450000137090683), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.StyleName = "PageInfo";
            this.textBox3.Value = "เลขที่";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0354337692260742), Telerik.Reporting.Drawing.Unit.Inch(0.92201203107833862));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.450000137090683), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.StyleName = "PageInfo";
            this.textBox5.Value = "วันที่";
            // 
            // prdONumberDataTextBox
            // 
            this.prdONumberDataTextBox.CanGrow = true;
            this.prdONumberDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.4855127334594727), Telerik.Reporting.Drawing.Unit.Inch(0.72193330526351929));
            this.prdONumberDataTextBox.Name = "prdONumberDataTextBox";
            this.prdONumberDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3345432281494141), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.prdONumberDataTextBox.Style.Font.Bold = true;
            this.prdONumberDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.prdONumberDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.prdONumberDataTextBox.StyleName = "Data";
            this.prdONumberDataTextBox.Value = "= Fields.PrdONumber";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Format = "{0:d}";
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.5062665939331055), Telerik.Reporting.Drawing.Unit.Inch(0.94476050138473511));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3137890100479126), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.currentTimeTextBox.Style.Font.Bold = true;
            this.currentTimeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.currentTimeTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "= Fields.PickingDate";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.0687642097473145), Telerik.Reporting.Drawing.Unit.Inch(1.0738482475280762));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62867546081542969), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox6.StyleName = "PageInfo";
            this.textBox6.Value = "เป้าหมาย";
            // 
            // prdQuantityDataTextBox
            // 
            this.prdQuantityDataTextBox.CanGrow = true;
            this.prdQuantityDataTextBox.Format = "{0:N3}";
            this.prdQuantityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7283463478088379), Telerik.Reporting.Drawing.Unit.Inch(1.0656331777572632));
            this.prdQuantityDataTextBox.Name = "prdQuantityDataTextBox";
            this.prdQuantityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3345432281494141), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.prdQuantityDataTextBox.Style.Font.Bold = true;
            this.prdQuantityDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.prdQuantityDataTextBox.StyleName = "Data";
            this.prdQuantityDataTextBox.Value = "=Fields.PrdQuantity";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0099999997764825821);
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1.9002794027328491);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox22,
            this.textBox7,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.materialCodeDataTextBox,
            this.textBox2,
            this.reportNameTextBox,
            this.textBox6,
            this.prdQuantityDataTextBox,
            this.textBox3,
            this.textBox5,
            this.prdONumberDataTextBox,
            this.currentTimeTextBox,
            this.pictureBox1,
            this.textBox4});
            this.reportHeader.Name = "reportHeader";
            // 
            // textBox22
            // 
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(9.5999984741210938), Telerik.Reporting.Drawing.Unit.Pixel(145.50077819824219));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(1028.4849853515625), Telerik.Reporting.Drawing.Unit.Pixel(36.926033020019531));
            this.textBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox22.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
            this.textBox22.Value = "";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.38958311080932617), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox7.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.StyleName = "Data";
            this.textBox7.Value = "ลำดับ";
            // 
            // textBox9
            // 
            this.textBox9.CanGrow = true;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.49999991059303284), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox9.Name = "textBox7";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8999996185302734), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox9.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.StyleName = "Data";
            this.textBox9.Value = "รายการ";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3999998569488525), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1999998092651367), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox10.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "batch";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = true;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5999999046325684), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000019073486328), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox11.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.StyleName = "Data";
            this.textBox11.Value = "จำนวนเบิก";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4000000953674316), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7999998927116394), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "เบิกเพิ่ม";
            // 
            // textBox13
            // 
            this.textBox13.CanGrow = true;
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.1999993324279785), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.599999725818634), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.StyleName = "Data";
            this.textBox13.Value = "L/C";
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = true;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7999992370605469), Telerik.Reporting.Drawing.Unit.Inch(1.5002007484436035));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7999998927116394), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.StyleName = "Data";
            this.textBox14.Value = "Short";
            // 
            // textBox15
            // 
            this.textBox15.CanGrow = true;
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.5999999046325684), Telerik.Reporting.Drawing.Unit.Inch(1.5002003908157349));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1000003814697266), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.textBox15.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.StyleName = "Data";
            this.textBox15.Value = "จำนวนคืน";
            // 
            // textBox16
            // 
            this.textBox16.CanGrow = true;
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6000785827636719), Telerik.Reporting.Drawing.Unit.Inch(1.7002793550491333));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49992117285728455), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.textBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.StyleName = "Data";
            this.textBox16.Value = "ของดี";
            // 
            // textBox17
            // 
            this.textBox17.CanGrow = true;
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1000785827636719), Telerik.Reporting.Drawing.Unit.Inch(1.7002793550491333));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.59992152452468872), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.textBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.StyleName = "Data";
            this.textBox17.Value = "ของเสีย";
            // 
            // textBox18
            // 
            this.textBox18.CanGrow = true;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.706669807434082), Telerik.Reporting.Drawing.Unit.Inch(1.5002003908157349));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1133861541748047), Telerik.Reporting.Drawing.Unit.Inch(0.40003922581672668));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.StyleName = "Data";
            this.textBox18.Value = "หมายเหตุ";
            // 
            // materialCodeDataTextBox
            // 
            this.materialCodeDataTextBox.CanGrow = true;
            this.materialCodeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.77507871389389038), Telerik.Reporting.Drawing.Unit.Inch(1.0656331777572632));
            this.materialCodeDataTextBox.Name = "materialCodeDataTextBox";
            this.materialCodeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7249209880828857), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224));
            this.materialCodeDataTextBox.Style.Font.Bold = true;
            this.materialCodeDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.materialCodeDataTextBox.StyleName = "Data";
            this.materialCodeDataTextBox.Value = "= Fields.MaterialCode + \' \' + Fields.MaterialName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(2.5410008430480957), Telerik.Reporting.Drawing.Unit.Mm(1.6770838499069214));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(54.999000549316406), Telerik.Reporting.Drawing.Unit.Mm(9.9999990463256836));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(239.66000366210938), Telerik.Reporting.Drawing.Unit.Mm(1.6770838499069214));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(35.000003814697266), Telerik.Reporting.Drawing.Unit.Mm(4.9999995231628418));
            this.textBox4.Style.Font.Name = "Arial";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.StyleName = "";
            this.textBox4.Value = "FM-PP-001-02";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.24988181889057159);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox24,
            this.textBox23,
            this.componentCodeDataTextBox,
            this.cLocCodeDataTextBox,
            this.textBox8,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox25});
            this.detail.Name = "detail";
            // 
            // textBox24
            // 
            this.textBox24.CanGrow = true;
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.6999998092651367), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1133854389190674), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.textBox24.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox24.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox24.StyleName = "Data";
            this.textBox24.Value = "";
            // 
            // textBox23
            // 
            this.textBox23.Angle = 0;
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(9.5999984741210938), Telerik.Reporting.Drawing.Unit.Pixel(0));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(1028.485107421875), Telerik.Reporting.Drawing.Unit.Pixel(23.988655090332031));
            this.textBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox23.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(0.5);
            this.textBox23.Value = "";
            // 
            // componentCodeDataTextBox
            // 
            this.componentCodeDataTextBox.CanGrow = true;
            this.componentCodeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.5), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.componentCodeDataTextBox.Name = "componentCodeDataTextBox";
            this.componentCodeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8999998569488525), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.componentCodeDataTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.componentCodeDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.componentCodeDataTextBox.StyleName = "Data";
            this.componentCodeDataTextBox.Value = "= Fields.ComponentCode";
            // 
            // cLocCodeDataTextBox
            // 
            this.cLocCodeDataTextBox.CanGrow = true;
            this.cLocCodeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.1999993324279785), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.cLocCodeDataTextBox.Name = "cLocCodeDataTextBox";
            this.cLocCodeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.60000038146972656), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.cLocCodeDataTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.cLocCodeDataTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.cLocCodeDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.cLocCodeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.cLocCodeDataTextBox.StyleName = "Data";
            this.cLocCodeDataTextBox.Value = "= Fields.cLocCode";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.38958311080932617), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.textBox8.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "= Fields.ItemNo";
            // 
            // textBox19
            // 
            this.textBox19.CanGrow = true;
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3999998569488525), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.textBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox19.StyleName = "Data";
            this.textBox19.Value = "= Fields.BatchNumber";
            // 
            // textBox20
            // 
            this.textBox20.CanGrow = true;
            this.textBox20.Format = "{0:N3}";
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.6000785827636719), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79992133378982544), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.textBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox20.StyleName = "Data";
            this.textBox20.Value = "= Fields.PickingQuantity";
            // 
            // textBox21
            // 
            this.textBox21.CanGrow = true;
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8000774383544922), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.textBox21.Name = "textBox20";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79992133378982544), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.textBox21.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.Font.Bold = true;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox21.StyleName = "Data";
            this.textBox21.Value = "= Fields.SH";
            // 
            // textBox25
            // 
            this.textBox25.CanGrow = true;
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.5999999046325684), Telerik.Reporting.Drawing.Unit.Inch(0));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49999967217445374), Telerik.Reporting.Drawing.Unit.Inch(0.23992125689983368));
            this.textBox25.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox25.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox25.StyleName = "Data";
            this.textBox25.Value = "";
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.78956633806228638);
            this.reportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox26,
            this.textBox27});
            this.reportFooterSection1.Name = "reportFooterSection1";
            // 
            // textBox26
            // 
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(205.5), Telerik.Reporting.Drawing.Unit.Mm(14.054980278015137));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(55.501979827880859), Telerik.Reporting.Drawing.Unit.Mm(4.5020022392272949));
            this.textBox26.Style.Font.Name = "Arial";
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox26.StyleName = "";
            this.textBox26.Value = "เจ้าหน้าที่วางแผนการผลิต";
            // 
            // textBox27
            // 
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(182.48124694824219), Telerik.Reporting.Drawing.Unit.Mm(8.2341470718383789));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(89.9999771118164), Telerik.Reporting.Drawing.Unit.Mm(7.500002384185791));
            this.textBox27.Style.Font.Name = "Arial";
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox27.StyleName = "";
            this.textBox27.Value = "Prepared  By ......................................(......./....../........)";
            // 
            // rptJobSheet
            // 
            this.Culture = new System.Globalization.CultureInfo("en-GB");
            this.DataSource = this.JobSheet;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.labelsGroup});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeader,
            this.labelsGroupFooter,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.detail,
            this.reportFooterSection1});
            this.Name = "rptJobSheet";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Mm(5);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Mm(5);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Mm(5);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Mm(5);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(280);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource JobSheet;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeader;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooter;
        private Telerik.Reporting.Group labelsGroup;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox prdONumberDataTextBox;
        private Telerik.Reporting.TextBox prdQuantityDataTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox componentCodeDataTextBox;
        private Telerik.Reporting.TextBox cLocCodeDataTextBox;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox materialCodeDataTextBox;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.ReportFooterSection reportFooterSection1;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox27;
    }
}