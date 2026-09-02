using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalityAppPoe
{
    public partial class ReportIssuesForm : Form
    {
        private Form mainMenu;
        private string attachedFilePath = "";

        // Global list to store issue submissions
        public static List<ServiceRequest> IssueList = new List<ServiceRequest>();

        public ReportIssuesForm(Form mainForm)
        {
            InitializeComponent();
            this.mainMenu = mainForm;

            // Prevent user form typing in ComboBox
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] {
                "-- Select a Category --",
                "Sanitation & Water",
                "Roads & Potholes",
                "Electricity & Outages",
                "Refuse & Waste Management",
                "Parks & Public Spaces",
                "Other / General Inquiry"
            });
            // Set default item to show text immediately on load
            cmbCategory.SelectedIndex = 0;

            // Attach change events for real-time progress bar updates
            this.txtLocation.TextChanged += new EventHandler(this.FormField_Changed);
            this.cmbCategory.SelectedIndexChanged += new EventHandler(this.FormField_Changed);
            this.rtbDescription.TextChanged += new EventHandler(this.FormField_Changed);
        }

        private void FormField_Changed(object sender, EventArgs e)
        {
            UpdateEngagementProgress();
        }

        private void UpdateEngagementProgress()
        {
            int score = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) score += 30;

            // Only add points if a REAL category is chosen (index > 0)
            if (cmbCategory.SelectedIndex > 0) score += 30;

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) score += 30;
            if (!string.IsNullOrEmpty(attachedFilePath)) score += 10;

            progressBarEngagement.Value = score;

            if (score == 0)
                lblEngagementStatus.Text = "Start filling out details to complete your report!";
            else if (score < 60)
                lblEngagementStatus.Text = "Good start! Please fill in location and category details.";
            else if (score < 100)
                lblEngagementStatus.Text = "Almost done! Add a description or media file to finalize.";
            else
                lblEngagementStatus.Text = "Awesome! Your report is fully documented and ready to submit!";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate that a valid category was chosen (not the placeholder at index 0)
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                cmbCategory.SelectedIndex <= 0 ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please complete all required fields (Location, Category, and Description) before submitting.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ServiceRequest newRequest = new ServiceRequest(
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                attachedFilePath
            );

            IssueList.Add(newRequest);

            // Reset fields back to initial state
            txtLocation.Clear();
            cmbCategory.SelectedIndex = 0; // Reset back to placeholder
            rtbDescription.Clear();
            attachedFilePath = "";
            lblAttachedFile.Text = "No file attached.";
            lblAttachedFile.ForeColor = Color.Gray;
            UpdateEngagementProgress();

            MessageBox.Show($"Thank you for your active participation!\n\nYour issue has been reported successfully.\nReference ID: {newRequest.RequestID}",
                            "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image and Document Files|*.jpg;*.jpeg;*.png;*.pdf;*.docx";
                dialog.Title = "Select Supporting Document or Image";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    attachedFilePath = dialog.FileName;
                    lblAttachedFile.Text = Path.GetFileName(attachedFilePath);
                    lblAttachedFile.ForeColor = Color.Green;
                    UpdateEngagementProgress();
                }
            }
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Close();
        }
    }
}