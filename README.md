# Udokotela
**Udokotela** is a WPF interface for a medical software, usable by hospital staff.

## 1. Setup for developers

### 1.1. Install Internet Information Services (IIS)
To install IIS on Windows 10, open **Programs and Features** in **Control Panel** and then select **Turn Windows features on or off**. In **Windows Features**, select **Internet Information Services** and then choose **OK**.

### 1.2. Configure a new applications pool
Open IIS Manager. In the **Connections** pane, expand the server node and click **Application Pools**. On the **Application Pools** page, in the **Actions** pane, click **Add Application Pool**. On the **Add Application Pool** dialog box, type *WCF Medical* as name for the application pool in the **Name** box. From the **Managed pipeline mode** list, select **Integrated** option. Select **Start application pool immediately** to start the application pool whenever the WWW service is started. By default, this is selected. Click **OK**.

### 1.3. Add a web site
Open IIS Manager. In the **Connections** pane, expand the server node and click **Sites**. On the **Sites** page, in the **Actions** pane, click **Add Web site**. On the **Add Web site** dialog box, fill the following information:
- Type *WCF Medical* as **Web site name**.
- Select *WCF Medical* as the **Applications pool**.
- Type *%SystemDrive%\inetpub\wwwroot\medical* as the **Physical access path**.
- In the **Link** panel, keep *http* as **Type** and just change the **Port** field to *8080*.
- Click **OK**.
