using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

using Microsoft.Win32;

namespace KON.NetworkProfileEditor
{
    [SupportedOSPlatform("windows7.0")]
    public class MainForm : Form
    {
        private ListBox lbProfiles;
        private GroupBox gbProfile;
        private Label lblProfileGUID;
        private TextBox tbProfileGUID;
        private Label lblProfileName;
        private TextBox tbProfileName;
        private Label lblProfileDescription;
        private TextBox tbProfileDescription;
        private Label lblProfileDateCreated;
        private TextBox tbProfileDateCreated;
        private Label lblProfileDateLastConnected;
        private TextBox tbProfileDateLastConnected;
        private Label lblProfileManaged;
        private ComboBox cbProfileManaged;
        private Label lblProfileCategory;
        private ComboBox cbProfileCategory;
        private Label lblProfileNameType;
        private ComboBox cbProfileNameType;
        private GroupBox gbSignatures;
        private Label lblSignatureID;
        private TextBox tbSignatureID;
        private Label lblSignatureDescription;
        private TextBox tbSignatureDescription;
        private Label lblSignatureDNSSuffix;
        private TextBox tbSignatureDNSSuffix;
        private Label lblSignatureFirstNetwork;
        private TextBox tbSignatureFirstNetwork;
        private Label lblSignatureDefaultGatewayMAC;
        private TextBox tbSignatureDefaultGatewayMAC;
        private Label lblSignatureSource;
        private TextBox tbSignatureSource;
        private Button btnSaveProfile;
        private Button btnDeleteProfile;
        private Button btnCleanupSignatures;

        public MainForm()
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                InitializeComponent();
                Global.LoadProfiles(lbProfiles);

                cbProfileManaged.Items.AddRange(Enum.GetNames(typeof(ePropertyManaged)));
                cbProfileCategory.Items.AddRange(Enum.GetNames(typeof(ePropertyCategory)));
                cbProfileNameType.Items.AddRange(Enum.GetNames(typeof(ePropertyNameType)));
            }
            else
                Console.WriteLine("Operating System or operating system version not supported");
        }
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            lbProfiles = new ListBox();
            gbProfile = new GroupBox();
            cbProfileNameType = new ComboBox();
            lblProfileNameType = new Label();
            cbProfileCategory = new ComboBox();
            lblProfileCategory = new Label();
            cbProfileManaged = new ComboBox();
            lblProfileManaged = new Label();
            tbProfileDateLastConnected = new TextBox();
            lblProfileDateLastConnected = new Label();
            tbProfileDateCreated = new TextBox();
            lblProfileDateCreated = new Label();
            tbProfileDescription = new TextBox();
            lblProfileDescription = new Label();
            tbProfileName = new TextBox();
            lblProfileName = new Label();
            tbProfileGUID = new TextBox();
            lblProfileGUID = new Label();
            gbSignatures = new GroupBox();
            tbSignatureSource = new TextBox();
            lblSignatureSource = new Label();
            tbSignatureDefaultGatewayMAC = new TextBox();
            lblSignatureDefaultGatewayMAC = new Label();
            tbSignatureFirstNetwork = new TextBox();
            lblSignatureFirstNetwork = new Label();
            tbSignatureDNSSuffix = new TextBox();
            lblSignatureDNSSuffix = new Label();
            tbSignatureDescription = new TextBox();
            lblSignatureDescription = new Label();
            tbSignatureID = new TextBox();
            lblSignatureID = new Label();
            btnCleanupSignatures = new Button();
            btnSaveProfile = new Button();
            btnDeleteProfile = new Button();
            gbProfile.SuspendLayout();
            gbSignatures.SuspendLayout();
            SuspendLayout();
            // 
            // lbProfiles
            // 
            lbProfiles.Dock = DockStyle.Left;
            lbProfiles.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbProfiles.FormattingEnabled = true;
            lbProfiles.Location = new Point(15, 15);
            lbProfiles.Margin = new Padding(4);
            lbProfiles.Name = "lbProfiles";
            lbProfiles.Size = new Size(481, 869);
            lbProfiles.TabIndex = 0;
            lbProfiles.SelectedIndexChanged += lbProfiles_SelectedIndexChanged;
            // 
            // gbProfile
            // 
            gbProfile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbProfile.Controls.Add(cbProfileNameType);
            gbProfile.Controls.Add(lblProfileNameType);
            gbProfile.Controls.Add(cbProfileCategory);
            gbProfile.Controls.Add(lblProfileCategory);
            gbProfile.Controls.Add(cbProfileManaged);
            gbProfile.Controls.Add(lblProfileManaged);
            gbProfile.Controls.Add(tbProfileDateLastConnected);
            gbProfile.Controls.Add(lblProfileDateLastConnected);
            gbProfile.Controls.Add(tbProfileDateCreated);
            gbProfile.Controls.Add(lblProfileDateCreated);
            gbProfile.Controls.Add(tbProfileDescription);
            gbProfile.Controls.Add(lblProfileDescription);
            gbProfile.Controls.Add(tbProfileName);
            gbProfile.Controls.Add(lblProfileName);
            gbProfile.Controls.Add(tbProfileGUID);
            gbProfile.Controls.Add(lblProfileGUID);
            gbProfile.Location = new Point(517, 15);
            gbProfile.Margin = new Padding(4);
            gbProfile.Name = "gbProfile";
            gbProfile.Padding = new Padding(4);
            gbProfile.Size = new Size(502, 303);
            gbProfile.TabIndex = 1;
            gbProfile.TabStop = false;
            gbProfile.Text = "Profile";
            // 
            // cbProfileNameType
            // 
            cbProfileNameType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProfileNameType.FormattingEnabled = true;
            cbProfileNameType.Location = new Point(180, 260);
            cbProfileNameType.Name = "cbProfileNameType";
            cbProfileNameType.Size = new Size(310, 28);
            cbProfileNameType.TabIndex = 21;
            // 
            // lblProfileNameType
            // 
            lblProfileNameType.AutoSize = true;
            lblProfileNameType.Location = new Point(16, 263);
            lblProfileNameType.Name = "lblProfileNameType";
            lblProfileNameType.Size = new Size(87, 20);
            lblProfileNameType.TabIndex = 15;
            lblProfileNameType.Text = "Name Type:";
            // 
            // cbProfileCategory
            // 
            cbProfileCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProfileCategory.FormattingEnabled = true;
            cbProfileCategory.Location = new Point(180, 226);
            cbProfileCategory.Name = "cbProfileCategory";
            cbProfileCategory.Size = new Size(310, 28);
            cbProfileCategory.TabIndex = 20;
            // 
            // lblProfileCategory
            // 
            lblProfileCategory.AutoSize = true;
            lblProfileCategory.Location = new Point(16, 229);
            lblProfileCategory.Name = "lblProfileCategory";
            lblProfileCategory.Size = new Size(72, 20);
            lblProfileCategory.TabIndex = 13;
            lblProfileCategory.Text = "Category:";
            // 
            // cbProfileManaged
            // 
            cbProfileManaged.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProfileManaged.Enabled = false;
            cbProfileManaged.FormattingEnabled = true;
            cbProfileManaged.Location = new Point(180, 192);
            cbProfileManaged.Name = "cbProfileManaged";
            cbProfileManaged.Size = new Size(310, 28);
            cbProfileManaged.TabIndex = 19;
            // 
            // lblProfileManaged
            // 
            lblProfileManaged.AutoSize = true;
            lblProfileManaged.Location = new Point(16, 195);
            lblProfileManaged.Name = "lblProfileManaged";
            lblProfileManaged.Size = new Size(75, 20);
            lblProfileManaged.TabIndex = 18;
            lblProfileManaged.Text = "Managed:";
            // 
            // tbProfileDateLastConnected
            // 
            tbProfileDateLastConnected.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbProfileDateLastConnected.Location = new Point(180, 159);
            tbProfileDateLastConnected.Name = "tbProfileDateLastConnected";
            tbProfileDateLastConnected.ReadOnly = true;
            tbProfileDateLastConnected.Size = new Size(310, 27);
            tbProfileDateLastConnected.TabIndex = 8;
            // 
            // lblProfileDateLastConnected
            // 
            lblProfileDateLastConnected.AutoSize = true;
            lblProfileDateLastConnected.Location = new Point(16, 162);
            lblProfileDateLastConnected.Name = "lblProfileDateLastConnected";
            lblProfileDateLastConnected.Size = new Size(149, 20);
            lblProfileDateLastConnected.TabIndex = 7;
            lblProfileDateLastConnected.Text = "Date Last Connected:";
            // 
            // tbProfileDateCreated
            // 
            tbProfileDateCreated.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbProfileDateCreated.Location = new Point(180, 126);
            tbProfileDateCreated.Name = "tbProfileDateCreated";
            tbProfileDateCreated.ReadOnly = true;
            tbProfileDateCreated.Size = new Size(310, 27);
            tbProfileDateCreated.TabIndex = 6;
            // 
            // lblProfileDateCreated
            // 
            lblProfileDateCreated.AutoSize = true;
            lblProfileDateCreated.Location = new Point(16, 129);
            lblProfileDateCreated.Name = "lblProfileDateCreated";
            lblProfileDateCreated.Size = new Size(100, 20);
            lblProfileDateCreated.TabIndex = 5;
            lblProfileDateCreated.Text = "Date Created:";
            // 
            // tbProfileDescription
            // 
            tbProfileDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbProfileDescription.Location = new Point(180, 93);
            tbProfileDescription.Name = "tbProfileDescription";
            tbProfileDescription.Size = new Size(310, 27);
            tbProfileDescription.TabIndex = 3;
            // 
            // lblProfileDescription
            // 
            lblProfileDescription.AutoSize = true;
            lblProfileDescription.Location = new Point(16, 96);
            lblProfileDescription.Name = "lblProfileDescription";
            lblProfileDescription.Size = new Size(88, 20);
            lblProfileDescription.TabIndex = 1;
            lblProfileDescription.Text = "Description:";
            // 
            // tbProfileName
            // 
            tbProfileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbProfileName.Location = new Point(180, 60);
            tbProfileName.Name = "tbProfileName";
            tbProfileName.Size = new Size(310, 27);
            tbProfileName.TabIndex = 2;
            // 
            // lblProfileName
            // 
            lblProfileName.AutoSize = true;
            lblProfileName.Location = new Point(16, 63);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(52, 20);
            lblProfileName.TabIndex = 0;
            lblProfileName.Text = "Name:";
            // 
            // tbProfileGUID
            // 
            tbProfileGUID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbProfileGUID.Location = new Point(180, 27);
            tbProfileGUID.Name = "tbProfileGUID";
            tbProfileGUID.ReadOnly = true;
            tbProfileGUID.Size = new Size(310, 27);
            tbProfileGUID.TabIndex = 12;
            // 
            // lblProfileGUID
            // 
            lblProfileGUID.AutoSize = true;
            lblProfileGUID.Location = new Point(16, 30);
            lblProfileGUID.Name = "lblProfileGUID";
            lblProfileGUID.Size = new Size(47, 20);
            lblProfileGUID.TabIndex = 11;
            lblProfileGUID.Text = "GUID:";
            // 
            // gbSignatures
            // 
            gbSignatures.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbSignatures.Controls.Add(tbSignatureSource);
            gbSignatures.Controls.Add(lblSignatureSource);
            gbSignatures.Controls.Add(tbSignatureDefaultGatewayMAC);
            gbSignatures.Controls.Add(lblSignatureDefaultGatewayMAC);
            gbSignatures.Controls.Add(tbSignatureFirstNetwork);
            gbSignatures.Controls.Add(lblSignatureFirstNetwork);
            gbSignatures.Controls.Add(tbSignatureDNSSuffix);
            gbSignatures.Controls.Add(lblSignatureDNSSuffix);
            gbSignatures.Controls.Add(tbSignatureDescription);
            gbSignatures.Controls.Add(lblSignatureDescription);
            gbSignatures.Controls.Add(tbSignatureID);
            gbSignatures.Controls.Add(lblSignatureID);
            gbSignatures.Location = new Point(517, 325);
            gbSignatures.Name = "gbSignatures";
            gbSignatures.Size = new Size(502, 244);
            gbSignatures.TabIndex = 23;
            gbSignatures.TabStop = false;
            gbSignatures.Text = "Signatures";
            // 
            // tbSignatureSource
            // 
            tbSignatureSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSignatureSource.Location = new Point(180, 198);
            tbSignatureSource.Name = "tbSignatureSource";
            tbSignatureSource.ReadOnly = true;
            tbSignatureSource.Size = new Size(310, 27);
            tbSignatureSource.TabIndex = 26;
            // 
            // lblSignatureSource
            // 
            lblSignatureSource.AutoSize = true;
            lblSignatureSource.Location = new Point(16, 201);
            lblSignatureSource.Name = "lblSignatureSource";
            lblSignatureSource.Size = new Size(57, 20);
            lblSignatureSource.TabIndex = 21;
            lblSignatureSource.Text = "Source:";
            // 
            // tbSignatureDefaultGatewayMAC
            // 
            tbSignatureDefaultGatewayMAC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSignatureDefaultGatewayMAC.Location = new Point(180, 165);
            tbSignatureDefaultGatewayMAC.Name = "tbSignatureDefaultGatewayMAC";
            tbSignatureDefaultGatewayMAC.ReadOnly = true;
            tbSignatureDefaultGatewayMAC.Size = new Size(310, 27);
            tbSignatureDefaultGatewayMAC.TabIndex = 20;
            // 
            // lblSignatureDefaultGatewayMAC
            // 
            lblSignatureDefaultGatewayMAC.AutoSize = true;
            lblSignatureDefaultGatewayMAC.Location = new Point(16, 168);
            lblSignatureDefaultGatewayMAC.Name = "lblSignatureDefaultGatewayMAC";
            lblSignatureDefaultGatewayMAC.Size = new Size(158, 20);
            lblSignatureDefaultGatewayMAC.TabIndex = 25;
            lblSignatureDefaultGatewayMAC.Text = "Default Gateway MAC:";
            // 
            // tbSignatureFirstNetwork
            // 
            tbSignatureFirstNetwork.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSignatureFirstNetwork.Location = new Point(180, 132);
            tbSignatureFirstNetwork.Name = "tbSignatureFirstNetwork";
            tbSignatureFirstNetwork.Size = new Size(310, 27);
            tbSignatureFirstNetwork.TabIndex = 22;
            // 
            // lblSignatureFirstNetwork
            // 
            lblSignatureFirstNetwork.AutoSize = true;
            lblSignatureFirstNetwork.Location = new Point(16, 135);
            lblSignatureFirstNetwork.Name = "lblSignatureFirstNetwork";
            lblSignatureFirstNetwork.Size = new Size(99, 20);
            lblSignatureFirstNetwork.TabIndex = 19;
            lblSignatureFirstNetwork.Text = "First Network:";
            // 
            // tbSignatureDNSSuffix
            // 
            tbSignatureDNSSuffix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSignatureDNSSuffix.Location = new Point(180, 99);
            tbSignatureDNSSuffix.Name = "tbSignatureDNSSuffix";
            tbSignatureDNSSuffix.Size = new Size(310, 27);
            tbSignatureDNSSuffix.TabIndex = 18;
            // 
            // lblSignatureDNSSuffix
            // 
            lblSignatureDNSSuffix.AutoSize = true;
            lblSignatureDNSSuffix.Location = new Point(16, 102);
            lblSignatureDNSSuffix.Name = "lblSignatureDNSSuffix";
            lblSignatureDNSSuffix.Size = new Size(83, 20);
            lblSignatureDNSSuffix.TabIndex = 17;
            lblSignatureDNSSuffix.Text = "DNS Suffix:";
            // 
            // tbSignatureDescription
            // 
            tbSignatureDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSignatureDescription.Location = new Point(180, 66);
            tbSignatureDescription.Name = "tbSignatureDescription";
            tbSignatureDescription.Size = new Size(310, 27);
            tbSignatureDescription.TabIndex = 16;
            // 
            // lblSignatureDescription
            // 
            lblSignatureDescription.AutoSize = true;
            lblSignatureDescription.Location = new Point(16, 69);
            lblSignatureDescription.Name = "lblSignatureDescription";
            lblSignatureDescription.Size = new Size(88, 20);
            lblSignatureDescription.TabIndex = 15;
            lblSignatureDescription.Text = "Description:";
            // 
            // tbSignatureID
            // 
            tbSignatureID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSignatureID.Location = new Point(180, 33);
            tbSignatureID.Name = "tbSignatureID";
            tbSignatureID.ReadOnly = true;
            tbSignatureID.Size = new Size(310, 27);
            tbSignatureID.TabIndex = 14;
            // 
            // lblSignatureID
            // 
            lblSignatureID.AutoSize = true;
            lblSignatureID.Location = new Point(16, 36);
            lblSignatureID.Name = "lblSignatureID";
            lblSignatureID.Size = new Size(27, 20);
            lblSignatureID.TabIndex = 13;
            lblSignatureID.Text = "ID:";
            // 
            // btnCleanupSignatures
            // 
            btnCleanupSignatures.Location = new Point(688, 575);
            btnCleanupSignatures.Name = "btnCleanupSignatures";
            btnCleanupSignatures.Size = new Size(162, 39);
            btnCleanupSignatures.TabIndex = 26;
            btnCleanupSignatures.Text = " Cleanup Signatures";
            btnCleanupSignatures.UseVisualStyleBackColor = true;
            btnCleanupSignatures.Click += btnCleanupSignatures_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Enabled = false;
            btnSaveProfile.Location = new Point(858, 575);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(162, 39);
            btnSaveProfile.TabIndex = 27;
            btnSaveProfile.Text = "Save Profile";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Enabled = false;
            btnDeleteProfile.Location = new Point(517, 575);
            btnDeleteProfile.Name = "btnDeleteProfile";
            btnDeleteProfile.Size = new Size(162, 39);
            btnDeleteProfile.TabIndex = 28;
            btnDeleteProfile.Text = "Delete Profile";
            btnDeleteProfile.UseVisualStyleBackColor = true;
            btnDeleteProfile.Click += btnDeleteProfile_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 899);
            Controls.Add(btnDeleteProfile);
            Controls.Add(btnSaveProfile);
            Controls.Add(btnCleanupSignatures);
            Controls.Add(gbSignatures);
            Controls.Add(gbProfile);
            Controls.Add(lbProfiles);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            Padding = new Padding(15);
            Text = "KON Network Profile Editor";
            gbProfile.ResumeLayout(false);
            gbProfile.PerformLayout();
            gbSignatures.ResumeLayout(false);
            gbSignatures.PerformLayout();
            ResumeLayout(false);
        }
        private void lbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                if (lbProfiles.SelectedItem != null)
                {
                    Profile pCurrentProfile = lbProfiles.SelectedItem as Profile;

                    tbProfileGUID.Text = pCurrentProfile.strGUID;
                    tbProfileName.Text = pCurrentProfile.strName;
                    tbProfileDescription.Text = pCurrentProfile.strDescription;
                    tbProfileDateCreated.Text = pCurrentProfile.dtDateCreated.ToString();
                    tbProfileDateLastConnected.Text = pCurrentProfile.dtDateLastConnected.ToString();
                    cbProfileManaged.Text = pCurrentProfile.epmManaged.ToString();
                    cbProfileCategory.Text = pCurrentProfile.epcCategory.ToString();
                    cbProfileNameType.Text = pCurrentProfile.epntNameType.ToString();

                    Signature sCurrentSignature = Global.LoadSignature(pCurrentProfile.epmManaged, pCurrentProfile.strGUID);
                    if (sCurrentSignature != null)
                    {
                        tbSignatureID.Text = sCurrentSignature.strSignatureID;
                        tbSignatureDescription.Text = sCurrentSignature.strDescription;
                        tbSignatureDescription.ReadOnly = false;
                        tbSignatureDNSSuffix.Text = sCurrentSignature.strDNSSuffix;
                        tbSignatureDNSSuffix.ReadOnly = false;
                        tbSignatureFirstNetwork.Text = sCurrentSignature.strFirstNetwork;
                        tbSignatureFirstNetwork.ReadOnly = false;
                        tbSignatureDefaultGatewayMAC.Text = sCurrentSignature.strDefaultGatewayMAC;
                        tbSignatureSource.Text = Convert.ToString(sCurrentSignature.iSource);
                    }
                    else
                    {
                        tbSignatureID.Text = string.Empty;
                        tbSignatureDescription.Text = string.Empty;
                        tbSignatureDescription.ReadOnly = true;
                        tbSignatureDNSSuffix.Text = string.Empty;
                        tbSignatureDNSSuffix.ReadOnly = true;
                        tbSignatureFirstNetwork.Text = string.Empty;
                        tbSignatureFirstNetwork.ReadOnly = true;
                        tbSignatureDefaultGatewayMAC.Text = string.Empty;
                        tbSignatureSource.Text = string.Empty;
                    }

                    btnSaveProfile.Enabled = btnDeleteProfile.Enabled = true;
                }
                else
                    btnSaveProfile.Enabled = btnDeleteProfile.Enabled = false;
            }
        }
        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                if (MessageBox.Show("This is dangerous and there is no way to recover the profile after you do this. Are you sure you want to delete this profile?", "Delete profile", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No && MessageBox.Show("One more time, this is DANGEROUS. Are you absolutely sure you want to delete this profile?", "Delete profile", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    RegistryKey rkProfiles = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles", writable: true);

                    if (rkProfiles != null)
                    {
                        Global.RemoveSignatureForProfile((lbProfiles.SelectedItem as Profile).epmManaged, (lbProfiles.SelectedItem as Profile).strGUID);
                        rkProfiles.DeleteSubKey((lbProfiles.SelectedItem as Profile).strGUID);
                    }

                    lbProfiles.Items.Remove(lbProfiles.SelectedItem);

                    if (lbProfiles.Items.Count > 0)
                        lbProfiles.SelectedIndex = 0;
                    else
                    {
                        tbProfileGUID.Text = string.Empty;
                        tbProfileName.Text = string.Empty;
                        tbProfileDescription.Text = string.Empty;
                        tbProfileDateCreated.Text = string.Empty;
                        tbProfileDateLastConnected.Text = string.Empty;
                        cbProfileManaged.Text = string.Empty;
                        cbProfileCategory.Text = string.Empty;
                        cbProfileNameType.Text = string.Empty;
                        tbSignatureID.Text = string.Empty;
                        tbSignatureDescription.Text = string.Empty;
                        tbSignatureDNSSuffix.Text = string.Empty;
                        tbSignatureFirstNetwork.Text = string.Empty;
                        tbSignatureDefaultGatewayMAC.Text = string.Empty;
                        tbSignatureSource.Text = string.Empty;
                    }
                }
            }
        }
        private void btnCleanupSignatures_Click(object sender, EventArgs e)
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                if (MessageBox.Show("This is dangerous and there is no way to recover the signatures after you do this. Are you sure you want to cleanup orphaned signatures?", "Cleanup signatures", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No && MessageBox.Show("One more time, this is DANGEROUS. Are you absolutely sure you want to cleanup orphaned signatures?", "Cleanup signatures", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    try
                    {
                        Global.CleanupSignatures();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                Profile pCurrentProfile = lbProfiles.SelectedItem as Profile;
                pCurrentProfile.rgRegistryKey.SetValue("ProfileName", tbProfileName.Text);
                pCurrentProfile.rgRegistryKey.SetValue("Description", tbProfileDescription.Text);
                pCurrentProfile.rgRegistryKey.SetValue("Category", Convert.ToInt32(Enum.Parse(typeof(ePropertyCategory), Convert.ToString(cbProfileCategory.SelectedItem))));
                pCurrentProfile.rgRegistryKey.SetValue("NameType", Convert.ToInt32(Enum.Parse(typeof(ePropertyNameType), Convert.ToString(cbProfileNameType.SelectedItem))));

                Signature sCurrentSignature = Global.LoadSignature(pCurrentProfile.epmManaged, pCurrentProfile.strGUID);
                if (sCurrentSignature != null)
                {
                    sCurrentSignature.rgRegistryKey.SetValue("Description", tbSignatureDescription.Text);
                    sCurrentSignature.rgRegistryKey.SetValue("DnsSuffix", tbSignatureDNSSuffix.Text);
                    sCurrentSignature.rgRegistryKey.SetValue("FirstNetwork", tbSignatureFirstNetwork.Text);
                }

                Profile pSavedProfile = new Profile(tbProfileGUID.Text, pCurrentProfile.rgRegistryKey);
                lbProfiles.Items.Insert(lbProfiles.SelectedIndex, pSavedProfile);
                lbProfiles.Items.Remove(pCurrentProfile);
                lbProfiles.SelectedItem = pSavedProfile;
            }
        }
    }
}