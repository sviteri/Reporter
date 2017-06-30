<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inconcert.aspx.cs" Inherits="Reportes.Inconcert" %>

<html5>
    <head>
    
    
    
    <script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/jquery/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/jquery-rightclick/jquery.rightClick.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083//inconcert/lib/webtoolkit/webtoolkit.md5.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/webtoolkit/webtoolkit.base64.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/shared/cookies/cookies.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/sessvars/sessvars.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/shared/scripts/inconcert.session_storage.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/jquery/jquery.jsonp-2.2.0.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/shared/inConcertSDK/inConcertSDK.js"> </script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/shared/inConcertSOA/inConcertSOA.js"> </script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/LAB/LAB.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/json/json2.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/javascriptools2/JavaScriptUtil.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/javascriptools2/Parsers.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/tree/dhtmlxcommon.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/tabbar/dhtmlxtabbar.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/combo/dhtmlxcombo.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/calendar/dhtmlxcalendar.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/lib/dhtmlx/tree/dhtmlxtree.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/lib/dhtmlx/tree/dhtmlxtree_kn.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/grid/dhtmlxgrid.js"></script> 
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/grid/dhtmlxgridcell.js"></script> 
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/menu/dhtmlxprotobar.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/menu/dhtmlxmenubar.js"></script>
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/menu/dhtmlxmenubar_cp.js"></script>
	
	
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/dhtmlx/windows/dhtmlxwindows.js"></script> 

	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/codemirror/lib/codemirror.js"></script>
	
	<script type="text/javascript" src="http://192.168.100.45:8083/inconcert/lib/codemirror/mode/javascript/javascript.js"></script>
	
	


<!--
<script type="text/javascript" src="themes/devel.js"> </script>
	<script type="text/javascript" src="themes/inconcert.designer.js"> </script>
<script type="text/javascript" src="themes/devel.js"> </script>
	<script type="text/javascript" src="themes/devel.js"> </script>
	-->
	
	<script>
	    var vAgentId;
	    var vOutboundEngine = new OutBoundEngine();
	    //var vVirtualCC = ui.getApplication().getVCCName();
	    //var vContactId;
	    //var vNumeroALlamar;
	    //var BaseClienteGestion = '';

	    //var app = ui.getApplication();
	    //vAgentId = app.getUser();
	    console.log('Log: ' + vOutboundEngine);
	    alert(vAgentId);

	</script>
  
 
</head>
    <body>
        <form runat="server" id="form1">
            <asp:Label ID="lbl_mensaje" Text="" runat="server"></asp:Label>
        </form>
    </body>
</html5>


