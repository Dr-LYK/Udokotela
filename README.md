# Udokotela
**Udokotela** is a WPF interface for a medical software, usable by hospital staff.

## 1. Setup for developers

### 1.1. First choice, IIS

#### 1.1.1. Install Internet Information Services (IIS)
To install IIS on Windows 10, open **Programs and Features** in **Control Panel** and then select **Turn Windows features on or off**. In **Windows Features**, select **Internet Information Services** and then choose **OK**.

#### 1.1.2. Configure a new applications pool
Open IIS Manager. In the **Connections** pane, expand the server node and click **Application Pools**. On the **Application Pools** page, in the **Actions** pane, click **Add Application Pool**.
- On the **Add Application Pool** dialog box, type "*WCF Medical*" as name for the application pool in the **Name** box.
- From the **Managed pipeline mode** list, select **Integrated** option.
- Select **Start application pool immediately** to start the application pool whenever the WWW service is started. By default, this is selected.
- Click **OK**.

#### 1.1.3. Add a web site
Open IIS Manager. In the **Connections** pane, expand the server node and click **Sites**. On the **Sites** page, in the **Actions** pane, click **Add Web site**. On the **Add Web site** dialog box, fill the following information:
- Type "*WCF Medical*" as **Web site name**.
- Select "*WCF Medical*" as the **Applications pool**.
- Type "*%SystemDrive%\inetpub\wwwroot\medical*" as the **Physical access path**.
- In the **Link** panel, keep "*http*" as **Type** and just change the **Port** field to "*3305*".
- Select **Start web site immediately** to start the web site whenever the WWW service is started. By default, this is selected.
- Click **OK**.

#### 1.1.4. Publish server project on IIS
Open the WCF Medical project on Visual Studio. In the **Generate** pane, click on **Publish Wcf-Medical**. On the window **Select publish target**, select **IIS, FTP, etc.** in the left side menu and click on **Publish** button. On the **Publish** dialog box, fill the following information:
- Select "*Web Deploy*" as the **Publish method**.
- Type "*localhost*"
- Type "*WCF Medical*"
- Type "*http://localhost:3305*"
- Click on **Validate connection** to check if the configuration is fine.
- Click on **Save** button to publish.

### 1.2. Second choice, Visual Studio 2017
Open the WCF Medical project on Visual Studio. Ensure that the "*Wcf-Medical*" is the main target by right-click on it and select **Define as start project**. Now you can run the serveur in debug mode with **F5** or without debug with **Ctrl+F5**. It will launch the server and open a page in a web browser. Don't worry if you have a "*4XX error*", everything is fine.

## 2. Information for designers

### 2.1. Colors

The list below details which colors are you used for the project, with its component name and its hexadecimal code:
- Top bar = Dark purple = #8E7CC3
- Left side bar = Light purple = #B4A7D6
