<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGestPermisos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGestPermisos))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro permisos", 31, 31)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro módulos", 32, 32)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro operaciones transacción", 33, 33)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestros", 30, 30, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar permisos", 34, 34)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar correo entrate y saliente", 35, 35)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria de cambios", 36, 36)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar usuarios", 37, 37)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendedores asociados a un coordinador", 38, 38)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cerrar aplicaciones en una ruta", 39, 39)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cerrar forzado", 40, 40)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Manuales", 41, 41)
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acerca de", 42, 42)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración", 15, 15, New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estado client vend", 45, 45)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Información clientes", 46, 46)
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trazabilidad clientes atendidos", 47, 47)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Super módulo de consulta de terceros", 48, 48)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes", 44, 44, New System.Windows.Forms.TreeNode() {TreeNode15, TreeNode16, TreeNode17, TreeNode18})
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Análisis pendientes", 51, 51)
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria de pedidos", 52, 52)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pendientes por ruta", 53, 53)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento de pendientes", 54, 54)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Super módulo de consulta(PENDIENTES)", 48, 48)
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pendientes", 50, 50, New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24})
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Análisis de ventas por linea de producción", 56, 56)
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Análisis valor kilo", 57, 57)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acumulado ventas", 58, 58)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acum vtas vend", 59, 59)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Principales clientes", 60, 60)
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Precios por debajo de", 61, 61)
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Programacion correrias", 62, 62)
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas cliente linea prod", 63, 63)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas cliente por ciudad", 64, 64)
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas client prod", 65, 65)
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas por zona", 66, 66)
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas cliente linea de producción (por mes)", 47, 47)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Super módulo  de consultas(Ventas)", 48, 48)
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas", 55, 55, New System.Windows.Forms.TreeNode() {TreeNode26, TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32, TreeNode33, TreeNode34, TreeNode35, TreeNode36, TreeNode37, TreeNode38})
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Super módulo  de consultas(Cartera)", 48, 48)
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fecha vencimiento cartera", 68, 68)
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cartera", 67, 67, New System.Windows.Forms.TreeNode() {TreeNode40, TreeNode41})
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Super módulo  de consultas(Recaudos)", 48, 48)
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recaudos", 69, 69, New System.Windows.Forms.TreeNode() {TreeNode43})
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Super módulo de consulta Costos por zona", 48, 48)
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gastos por zona", 70, 70, New System.Windows.Forms.TreeNode() {TreeNode45})
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ajuste contabilidad", 72, 72)
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contabilidad", 71, 71, New System.Windows.Forms.TreeNode() {TreeNode47})
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informes", 49, 49, New System.Windows.Forms.TreeNode() {TreeNode19, TreeNode25, TreeNode39, TreeNode42, TreeNode44, TreeNode46, TreeNode48})
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ingreso ventas", 73, 73)
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pendientes problema", 74, 74)
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seg vendedor", 75, 75)
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cartera", 76, 76)
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pendientes", 77, 77)
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Despachos", 78, 78)
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movil")
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ingreso ventas", 73, 73, New System.Windows.Forms.TreeNode() {TreeNode50, TreeNode51, TreeNode52, TreeNode53, TreeNode54, TreeNode55, TreeNode56})
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar", 80, 80)
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto ventas", 79, 79)
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto ventas", 79, 79, New System.Windows.Forms.TreeNode() {TreeNode58, TreeNode59})
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar ppto rec", 80, 80)
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto de recaudo", 81, 81)
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto recaudo", 81, 81, New System.Windows.Forms.TreeNode() {TreeNode61, TreeNode62})
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seg vendedores", 47, 47)
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seg presupuesto", 75, 75)
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seg Lineas", 75, 75)
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Anticipos", 36, 36)
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento de presupuestos (MES)", 48, 48)
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento vendedores", 47, 47, New System.Windows.Forms.TreeNode() {TreeNode64, TreeNode65, TreeNode66, TreeNode67, TreeNode68})
        Dim TreeNode70 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quejas y reclamos", 83, 83)
        Dim TreeNode71 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Encuesta clientes nacionales", 84, 84)
        Dim TreeNode72 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar encuestas", 80, 80)
        Dim TreeNode73 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("SAC", 82, 82, New System.Windows.Forms.TreeNode() {TreeNode70, TreeNode71, TreeNode72})
        Dim TreeNode74 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reglas", 86, 86)
        Dim TreeNode75 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Liquidar comisiones (informe)", 87, 87)
        Dim TreeNode76 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comisiones", 85, 85, New System.Windows.Forms.TreeNode() {TreeNode74, TreeNode75})
        Dim TreeNode77 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cambiar Cart-Pend-Terceros de vendedor", 36, 36)
        Dim TreeNode78 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Admisnistrar cambios", 15, 15, New System.Windows.Forms.TreeNode() {TreeNode77})
        Dim TreeNode79 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion de Documentación", 88, 88)
        Dim TreeNode80 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Oficinas", 43, 43, New System.Windows.Forms.TreeNode() {TreeNode49, TreeNode57, TreeNode60, TreeNode63, TreeNode69, TreeNode73, TreeNode76, TreeNode78, TreeNode79})
        Dim TreeNode81 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar desperdicios", 123, 123)
        Dim TreeNode82 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventarios de metrología", 124, 124)
        Dim TreeNode83 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ambiental", 122, 122, New System.Windows.Forms.TreeNode() {TreeNode81, TreeNode82})
        Dim TreeNode84 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recocido", 96, 96)
        Dim TreeNode85 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reporte Inspeccion calidad", 149, 149)
        Dim TreeNode86 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Calidad", 95, 95, New System.Windows.Forms.TreeNode() {TreeNode84, TreeNode85})
        Dim TreeNode87 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Puntilleria", 97, 97)
        Dim TreeNode88 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Púas", 97, 97)
        Dim TreeNode89 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Galvanizado(forma1)solo consultas", 97, 97)
        Dim TreeNode90 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Galvanizado (forma2)", 97, 97)
        Dim TreeNode91 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trefilación (Forma 2)", 97, 97)
        Dim TreeNode92 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trefilación (Forma 3)", 97, 97)
        Dim TreeNode93 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pulimiento(tambores)", 97, 97)
        Dim TreeNode94 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Galvanizado por baches", 97, 97)
        Dim TreeNode95 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recocido", 97, 97)
        Dim TreeNode96 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tornilleria", 97, 97)
        Dim TreeNode97 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tratamientos termicos (Temple)", 97, 97)
        Dim TreeNode98 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Empaque de puntilleria", 126, 126)
        Dim TreeNode99 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transacción manual DMS-SPIC", 125, 125)
        Dim TreeNode100 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ingreso de producción", 97, 97, New System.Windows.Forms.TreeNode() {TreeNode87, TreeNode88, TreeNode89, TreeNode90, TreeNode91, TreeNode92, TreeNode93, TreeNode94, TreeNode95, TreeNode96, TreeNode97, TreeNode98, TreeNode99})
        Dim TreeNode101 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar certificados historicos", 5, 5)
        Dim TreeNode102 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar certificado de calidad", 98, 98)
        Dim TreeNode103 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro fichas técnicas", 99, 99)
        Dim TreeNode104 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Certificados de calidad", 98, 98, New System.Windows.Forms.TreeNode() {TreeNode101, TreeNode102, TreeNode103})
        Dim TreeNode105 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pendientes producción", 100, 100)
        Dim TreeNode106 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Historico ventas", 101, 101)
        Dim TreeNode107 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movimiento inventario", 102, 102)
        Dim TreeNode108 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Eficiencias")
        Dim TreeNode109 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar transacciones Dms", 5, 5)
        Dim TreeNode110 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trazabilidad de transacciones", 127, 127)
        Dim TreeNode111 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe de máximos y minimos", 127, 127)
        Dim TreeNode112 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entradas-salidas-inventarios", 127, 127)
        Dim TreeNode113 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entradas_salidas_DIARIO", 128, 128)
        Dim TreeNode114 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informes", 49, 49, New System.Windows.Forms.TreeNode() {TreeNode104, TreeNode105, TreeNode106, TreeNode107, TreeNode108, TreeNode109, TreeNode110, TreeNode111, TreeNode112, TreeNode113})
        Dim TreeNode115 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar transacciones sin stock", 104, 104)
        Dim TreeNode116 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de bodega (handheld)", 105, 105)
        Dim TreeNode117 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro Transaccion HandHeld", 106, 106)
        Dim TreeNode118 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Módulo traslados de bodega", 103, 103, New System.Windows.Forms.TreeNode() {TreeNode115, TreeNode116, TreeNode117})
        Dim TreeNode119 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nuevos repuestos", 108, 108)
        Dim TreeNode120 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitud de correción", 109, 109)
        Dim TreeNode121 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mantenimiento", 107, 107, New System.Windows.Forms.TreeNode() {TreeNode119, TreeNode120})
        Dim TreeNode122 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto de producción", 110, 110)
        Dim TreeNode123 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento de presupuesto de producción", 127, 127)
        Dim TreeNode124 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe Diferencia Trefilacion", 111, 111)
        Dim TreeNode125 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto de producción", 110, 110, New System.Windows.Forms.TreeNode() {TreeNode122, TreeNode123, TreeNode124})
        Dim TreeNode126 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto de articulos", 113, 113)
        Dim TreeNode127 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto de articulos", 113, 113, New System.Windows.Forms.TreeNode() {TreeNode126})
        Dim TreeNode128 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto", 114, 114)
        Dim TreeNode129 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento presupuesto de gastos y articulos", 127, 127)
        Dim TreeNode130 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuesto de gastos y articulos", 112, 112, New System.Windows.Forms.TreeNode() {TreeNode127, TreeNode128, TreeNode129})
        Dim TreeNode131 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar tiquetes terminado", 116, 116)
        Dim TreeNode132 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar planilla separe", 117, 117)
        Dim TreeNode133 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar tornilleria", 115, 115, New System.Windows.Forms.TreeNode() {TreeNode131, TreeNode132})
        Dim TreeNode134 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salida materia de prima (2-11 y 11-2)", 129, 129)
        Dim TreeNode135 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta materia prima (2-11 y 11-2)", 136, 136)
        Dim TreeNode136 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orden de produción galv", 130, 130)
        Dim TreeNode137 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe producción galvanizado", 49, 49)
        Dim TreeNode138 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe estado de rollos", 135, 135)
        Dim TreeNode139 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bobinas detenidas", 131, 131)
        Dim TreeNode140 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tiempo trabajo", 132, 132)
        Dim TreeNode141 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Resumen galvanizado", 133, 133)
        Dim TreeNode142 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe de paros", 134, 134)
        Dim TreeNode143 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Galvanizado", 118, 118, New System.Windows.Forms.TreeNode() {TreeNode134, TreeNode135, TreeNode136, TreeNode137, TreeNode138, TreeNode139, TreeNode140, TreeNode141, TreeNode142})
        Dim TreeNode144 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar inventarios fisicos", 119, 119)
        Dim TreeNode145 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria Inventario", 127, 127)
        Dim TreeNode146 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventarios fisicos", 119, 119, New System.Windows.Forms.TreeNode() {TreeNode144, TreeNode145})
        Dim TreeNode147 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitar materia prima", 35, 35)
        Dim TreeNode148 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar solicitudes", 5, 5)
        Dim TreeNode149 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orden de producción", 130, 130)
        Dim TreeNode150 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria Puntilleria", 127, 127)
        Dim TreeNode151 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Puntilleria", 121, 121, New System.Windows.Forms.TreeNode() {TreeNode147, TreeNode148, TreeNode149, TreeNode150})
        Dim TreeNode152 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitar materia prima", 35, 35)
        Dim TreeNode153 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar solicitudes", 5, 5)
        Dim TreeNode154 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orden de produccion Recocido", 130, 130)
        Dim TreeNode155 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria Recocido", 127, 127)
        Dim TreeNode156 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria Tref-Rec", 127, 127)
        Dim TreeNode157 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Copia tiquete recocido", 137, 137)
        Dim TreeNode158 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tiquete no conforme", 92, 92)
        Dim TreeNode159 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recocido", 96, 96, New System.Windows.Forms.TreeNode() {TreeNode152, TreeNode153, TreeNode154, TreeNode155, TreeNode156, TreeNode157, TreeNode158})
        Dim TreeNode160 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitar materia prima", 35, 35)
        Dim TreeNode161 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar solicitudes", 5, 5)
        Dim TreeNode162 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orden de producción operario", 130, 130)
        Dim TreeNode163 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Crear orden puas", 120, 120)
        Dim TreeNode164 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Producción de puas", 71, 71)
        Dim TreeNode165 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe de paros púas", 134, 134)
        Dim TreeNode166 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Alambre de Puas", 118, 118, New System.Windows.Forms.TreeNode() {TreeNode160, TreeNode161, TreeNode162, TreeNode163, TreeNode164, TreeNode165})
        Dim TreeNode167 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Crear proyecto", 69, 69)
        Dim TreeNode168 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar proyectos", 136, 136)
        Dim TreeNode169 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar proyectos", 127, 127, New System.Windows.Forms.TreeNode() {TreeNode167, TreeNode168})
        Dim TreeNode170 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitud scal", 138, 138)
        Dim TreeNode171 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitud scae", 138, 138)
        Dim TreeNode172 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitud sar", 138, 138)
        Dim TreeNode173 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitud sav", 138, 138)
        Dim TreeNode174 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta de pedidos scal", 136, 136)
        Dim TreeNode175 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta de pedidos scae", 136, 136)
        Dim TreeNode176 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta de pedidos sar", 136, 136)
        Dim TreeNode177 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta de pedidos sav", 136, 136)
        Dim TreeNode178 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consumos scal,scae,sar y sav", 138, 138, New System.Windows.Forms.TreeNode() {TreeNode170, TreeNode171, TreeNode172, TreeNode173, TreeNode174, TreeNode175, TreeNode176, TreeNode177})
        Dim TreeNode179 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ordenes de producción", 130, 130)
        Dim TreeNode180 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria de alambres", 127, 127)
        Dim TreeNode181 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar tiquete tref NC", 139, 139)
        Dim TreeNode182 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar linea de producción", 94, 94)
        Dim TreeNode183 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Limite consumos alambron", 125, 125)
        Dim TreeNode184 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Velocidades de codigos", 141, 141)
        Dim TreeNode185 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Saldo alambron", 114, 114)
        Dim TreeNode186 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Actualizar alambron", 142, 142)
        Dim TreeNode187 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta tref forma 3", 136, 136)
        Dim TreeNode188 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trefilación", 118, 118, New System.Windows.Forms.TreeNode() {TreeNode179, TreeNode180, TreeNode181, TreeNode182, TreeNode183, TreeNode184, TreeNode185, TreeNode186, TreeNode187})
        Dim TreeNode189 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consumo de tornileria", 115, 115)
        Dim TreeNode190 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tornilleria", 115, 115, New System.Windows.Forms.TreeNode() {TreeNode189})
        Dim TreeNode191 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("consumo y producción de tref", 138, 138)
        Dim TreeNode192 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("consumo y producción de punt", 138, 138)
        Dim TreeNode193 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("consumo y produccion galv", 138, 138)
        Dim TreeNode194 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguimiento de consumos", 138, 138, New System.Windows.Forms.TreeNode() {TreeNode191, TreeNode192, TreeNode193})
        Dim TreeNode195 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cambiar centro (Planta)", 142, 142)
        Dim TreeNode196 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria", 127, 127)
        Dim TreeNode197 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Producción", 94, 94, New System.Windows.Forms.TreeNode() {TreeNode83, TreeNode86, TreeNode100, TreeNode114, TreeNode118, TreeNode121, TreeNode125, TreeNode130, TreeNode133, TreeNode143, TreeNode146, TreeNode151, TreeNode159, TreeNode166, TreeNode169, TreeNode178, TreeNode188, TreeNode190, TreeNode194, TreeNode195, TreeNode196})
        Dim TreeNode198 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe personal Dane", 138, 138)
        Dim TreeNode199 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe Personal Activo", 138, 138)
        Dim TreeNode200 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Información de empleados", 138, 138)
        Dim TreeNode201 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe de incapacidades y ausentismos", 137, 137)
        Dim TreeNode202 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Días de vacaciones", 143, 143)
        Dim TreeNode203 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tiempos laborados", 132, 132)
        Dim TreeNode204 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rotación del personal", 142, 142)
        Dim TreeNode205 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Registrar personal maquilas", 45, 45)
        Dim TreeNode206 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe temporales", 137, 137)
        Dim TreeNode207 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personal maquilas", 45, 45, New System.Windows.Forms.TreeNode() {TreeNode205, TreeNode206})
        Dim TreeNode208 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Procesar marcaciones", 141, 141)
        Dim TreeNode209 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Programación de turnos", 71, 71)
        Dim TreeNode210 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar periodos de corte de novedades", 107, 107)
        Dim TreeNode211 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe de inconsistencia en marcaciones", 127, 127)
        Dim TreeNode212 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar compromisos", 71, 71)
        Dim TreeNode213 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informe de novedades pendientes", 71, 71)
        Dim TreeNode214 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personal en Corsan", 138, 138)
        Dim TreeNode215 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reloj", 132, 132, New System.Windows.Forms.TreeNode() {TreeNode207, TreeNode208, TreeNode209, TreeNode210, TreeNode211, TreeNode212, TreeNode213, TreeNode214})
        Dim TreeNode216 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evaluacion de desempeño", 125, 125)
        Dim TreeNode217 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar evaluaciónes de desempeño", 136, 136)
        Dim TreeNode218 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Permisos evaluaciones", 52, 52)
        Dim TreeNode219 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evaluaciones de desempeño", 125, 125, New System.Windows.Forms.TreeNode() {TreeNode216, TreeNode217, TreeNode218})
        Dim TreeNode220 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Buzon de Sugerencias", 34, 34)
        Dim TreeNode221 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consulta Solicitud de Premios", 52, 52)
        Dim TreeNode222 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar contratistas", 37, 37)
        Dim TreeNode223 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contratistas", 37, 37, New System.Windows.Forms.TreeNode() {TreeNode222})
        Dim TreeNode224 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recursos humanos", 44, 44, New System.Windows.Forms.TreeNode() {TreeNode198, TreeNode199, TreeNode200, TreeNode201, TreeNode202, TreeNode203, TreeNode204, TreeNode215, TreeNode219, TreeNode220, TreeNode221, TreeNode223})
        Dim TreeNode225 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar votaciónes", 136, 136)
        Dim TreeNode226 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar grupos votación", 83, 83)
        Dim TreeNode227 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ingresar votación", 140, 140)
        Dim TreeNode228 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administrar votación", 83, 83, New System.Windows.Forms.TreeNode() {TreeNode225, TreeNode226, TreeNode227})
        Dim TreeNode229 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar", 5, 5)
        Dim TreeNode230 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evaluación", 145, 145)
        Dim TreeNode231 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Graficar evaluaciones", 127, 127)
        Dim TreeNode232 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro proveedor-categoria", 99, 99)
        Dim TreeNode233 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar_tendencias", 86, 86)
        Dim TreeNode234 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evaluación de proveedores", 145, 145, New System.Windows.Forms.TreeNode() {TreeNode229, TreeNode230, TreeNode231, TreeNode232, TreeNode233})
        Dim TreeNode235 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar solicitud de servicio", 69, 69)
        Dim TreeNode236 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administrar solicitudes de servicios", 120, 120)
        Dim TreeNode237 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar material aut vs reg", 136, 136)
        Dim TreeNode238 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Solicitudes de servicio", 109, 109, New System.Windows.Forms.TreeNode() {TreeNode235, TreeNode236, TreeNode237})
        Dim TreeNode239 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administrar ordenes de compra", 144, 144)
        Dim TreeNode240 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar orden de compra", 69, 69)
        Dim TreeNode241 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ordenes de compra", 144, 144, New System.Windows.Forms.TreeNode() {TreeNode239, TreeNode240})
        Dim TreeNode242 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar salida de almacen", 147, 147)
        Dim TreeNode243 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar salidas de almacen", 136, 136)
        Dim TreeNode244 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salidas de almacen", 147, 147, New System.Windows.Forms.TreeNode() {TreeNode242, TreeNode243})
        Dim TreeNode245 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salida de alambrón", 118, 118)
        Dim TreeNode246 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar salida de alambrón", 136, 136)
        Dim TreeNode247 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salidas de alambrón", 118, 118, New System.Windows.Forms.TreeNode() {TreeNode245, TreeNode246})
        Dim TreeNode248 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tiquetes de alambrón", 116, 116)
        Dim TreeNode249 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria de ingreso de materia prima", 127, 127)
        Dim TreeNode250 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planillas de descargue de alambrón", 78, 78)
        Dim TreeNode251 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Menú principal Hand-Held", 105, 105)
        Dim TreeNode252 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestión de alambrón", 118, 118, New System.Windows.Forms.TreeNode() {TreeNode248, TreeNode249, TreeNode250, TreeNode251})
        Dim TreeNode253 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Información estupefacientes", 148, 148)
        Dim TreeNode254 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estupefacientes", 148, 148, New System.Windows.Forms.TreeNode() {TreeNode253})
        Dim TreeNode255 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar tiquetes producto temrinado", 116, 116)
        Dim TreeNode256 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tiquetes producto terminado", 116, 116, New System.Windows.Forms.TreeNode() {TreeNode255})
        Dim TreeNode257 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras", 144, 144, New System.Windows.Forms.TreeNode() {TreeNode234, TreeNode238, TreeNode241, TreeNode244, TreeNode247, TreeNode252, TreeNode254, TreeNode256})
        Dim TreeNode258 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar procedimientos", 136, 136)
        Dim TreeNode259 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar procedimientos", 69, 69)
        Dim TreeNode260 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maestro cargos", 99, 99)
        Dim TreeNode261 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auditoria", 127, 127, New System.Windows.Forms.TreeNode() {TreeNode258, TreeNode259, TreeNode260})
        Dim TreeNode262 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cambiar pedido bodega", 36, 36)
        Dim TreeNode263 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Relación factura-pedido-entrega", 90, 90)
        Dim TreeNode264 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Formato impresión etiquetas", 27, 27)
        Dim TreeNode265 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestionar producto no conforme", 10, 10)
        Dim TreeNode266 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de la  B 2 a la 3", 150, 150)
        Dim TreeNode267 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Control Esatado maquinas", 151, 151)
        Dim TreeNode268 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Logistica", 89, 89, New System.Windows.Forms.TreeNode() {TreeNode262, TreeNode263, TreeNode264, TreeNode265, TreeNode266, TreeNode267})
        Me.listaTipoUsu = New System.Windows.Forms.ListBox()
        Me.listPermisosUsuario = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddmodulo = New System.Windows.Forms.Button()
        Me.btnQuitarMod = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'listaTipoUsu
        '
        Me.listaTipoUsu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listaTipoUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listaTipoUsu.FormattingEnabled = True
        Me.listaTipoUsu.ItemHeight = 16
        Me.listaTipoUsu.Location = New System.Drawing.Point(12, 28)
        Me.listaTipoUsu.Name = "listaTipoUsu"
        Me.listaTipoUsu.Size = New System.Drawing.Size(187, 404)
        Me.listaTipoUsu.TabIndex = 1
        '
        'listPermisosUsuario
        '
        Me.listPermisosUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listPermisosUsuario.FormattingEnabled = True
        Me.listPermisosUsuario.Items.AddRange(New Object() {""})
        Me.listPermisosUsuario.Location = New System.Drawing.Point(210, 28)
        Me.listPermisosUsuario.Name = "listPermisosUsuario"
        Me.listPermisosUsuario.Size = New System.Drawing.Size(187, 407)
        Me.listPermisosUsuario.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo de usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(273, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Permisos del usuario"
        '
        'btnAddmodulo
        '
        Me.btnAddmodulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddmodulo.Location = New System.Drawing.Point(403, 166)
        Me.btnAddmodulo.Name = "btnAddmodulo"
        Me.btnAddmodulo.Size = New System.Drawing.Size(37, 26)
        Me.btnAddmodulo.TabIndex = 39
        Me.btnAddmodulo.Text = "<<"
        Me.btnAddmodulo.UseVisualStyleBackColor = True
        '
        'btnQuitarMod
        '
        Me.btnQuitarMod.Image = CType(resources.GetObject("btnQuitarMod.Image"), System.Drawing.Image)
        Me.btnQuitarMod.Location = New System.Drawing.Point(402, 198)
        Me.btnQuitarMod.Name = "btnQuitarMod"
        Me.btnQuitarMod.Size = New System.Drawing.Size(37, 26)
        Me.btnQuitarMod.TabIndex = 40
        Me.btnQuitarMod.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(443, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Módulos"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icoProg.png")
        Me.ImageList1.Images.SetKeyName(1, "1349366316_users.ico")
        Me.ImageList1.Images.SetKeyName(2, "dinero.jpg")
        Me.ImageList1.Images.SetKeyName(3, "est.jpg")
        Me.ImageList1.Images.SetKeyName(4, "usuario1.gif")
        Me.ImageList1.Images.SetKeyName(5, "buscar7.gif")
        Me.ImageList1.Images.SetKeyName(6, "mas1.png")
        Me.ImageList1.Images.SetKeyName(7, "casco.jpg")
        Me.ImageList1.Images.SetKeyName(8, "casco1.jpg")
        Me.ImageList1.Images.SetKeyName(9, "despacho.png")
        Me.ImageList1.Images.SetKeyName(10, "planilla.gif")
        Me.ImageList1.Images.SetKeyName(11, "informe.png")
        Me.ImageList1.Images.SetKeyName(12, "actualizar.png")
        Me.ImageList1.Images.SetKeyName(13, "tool.png")
        Me.ImageList1.Images.SetKeyName(14, "Black_Tools.png")
        Me.ImageList1.Images.SetKeyName(15, "configuracion.png")
        Me.ImageList1.Images.SetKeyName(16, "ficha.png")
        Me.ImageList1.Images.SetKeyName(17, "mobil.ico")
        Me.ImageList1.Images.SetKeyName(18, "ok.png")
        Me.ImageList1.Images.SetKeyName(19, "compras.png")
        Me.ImageList1.Images.SetKeyName(20, "compras1.png")
        Me.ImageList1.Images.SetKeyName(21, "compras2.png")
        Me.ImageList1.Images.SetKeyName(22, "compras4.png")
        Me.ImageList1.Images.SetKeyName(23, "compras5.png")
        Me.ImageList1.Images.SetKeyName(24, "Time_management.png")
        Me.ImageList1.Images.SetKeyName(25, "grafico10.png")
        Me.ImageList1.Images.SetKeyName(26, "ok3.gif")
        Me.ImageList1.Images.SetKeyName(27, "imp.ico")
        Me.ImageList1.Images.SetKeyName(28, "imp.ico")
        Me.ImageList1.Images.SetKeyName(29, "natural.png")
        Me.ImageList1.Images.SetKeyName(30, "maestros.png")
        Me.ImageList1.Images.SetKeyName(31, "maestro_permisos.png")
        Me.ImageList1.Images.SetKeyName(32, "maestro_modulos.png")
        Me.ImageList1.Images.SetKeyName(33, "maestro_operaciones_transaccion.png")
        Me.ImageList1.Images.SetKeyName(34, "gestionar_permisos.png")
        Me.ImageList1.Images.SetKeyName(35, "gestionar_correo_entrante_y_saliente.png")
        Me.ImageList1.Images.SetKeyName(36, "auditoria_de_cambios.png")
        Me.ImageList1.Images.SetKeyName(37, "gestionar_usuarios.png")
        Me.ImageList1.Images.SetKeyName(38, "vendedores_asociados_a_un_coordinador.png")
        Me.ImageList1.Images.SetKeyName(39, "cerrar_aplicaciones_en_una_ruta.png")
        Me.ImageList1.Images.SetKeyName(40, "cerrar_forzado.png")
        Me.ImageList1.Images.SetKeyName(41, "manuales.png")
        Me.ImageList1.Images.SetKeyName(42, "acerca_de.png")
        Me.ImageList1.Images.SetKeyName(43, "oficinas.png")
        Me.ImageList1.Images.SetKeyName(44, "clientes.png")
        Me.ImageList1.Images.SetKeyName(45, "estado_cliente_vend.png")
        Me.ImageList1.Images.SetKeyName(46, "informacion_clientes.png")
        Me.ImageList1.Images.SetKeyName(47, "trazabilidad_clientes_atentidos.png")
        Me.ImageList1.Images.SetKeyName(48, "super_modulo_de_consultas_de_terceros.png")
        Me.ImageList1.Images.SetKeyName(49, "informes.png")
        Me.ImageList1.Images.SetKeyName(50, "pendientes.png")
        Me.ImageList1.Images.SetKeyName(51, "analisis_pendientes.png")
        Me.ImageList1.Images.SetKeyName(52, "auditoria_de_pedidos.png")
        Me.ImageList1.Images.SetKeyName(53, "pendientes_por_ruta.png")
        Me.ImageList1.Images.SetKeyName(54, "seguimiento_pendientes.png")
        Me.ImageList1.Images.SetKeyName(55, "ventas.png")
        Me.ImageList1.Images.SetKeyName(56, "analisis_de_ventas_por_linea_de_produccion.png")
        Me.ImageList1.Images.SetKeyName(57, "analisis_valor_kilo.png")
        Me.ImageList1.Images.SetKeyName(58, "acomulado ventas.png")
        Me.ImageList1.Images.SetKeyName(59, "acum_vtas_vend.png")
        Me.ImageList1.Images.SetKeyName(60, "principales_clientes.png")
        Me.ImageList1.Images.SetKeyName(61, "precios_por_debajo_de.png")
        Me.ImageList1.Images.SetKeyName(62, "programacion_correrias.png")
        Me.ImageList1.Images.SetKeyName(63, "ventas_cliente_linea_prod.png")
        Me.ImageList1.Images.SetKeyName(64, "ventas_cliente_por_ciudad.png")
        Me.ImageList1.Images.SetKeyName(65, "ventas_client_prod.png")
        Me.ImageList1.Images.SetKeyName(66, "ventas_por_zona.png")
        Me.ImageList1.Images.SetKeyName(67, "cartera.png")
        Me.ImageList1.Images.SetKeyName(68, "fecha_vencimiento_cartera.png")
        Me.ImageList1.Images.SetKeyName(69, "recaudos.png")
        Me.ImageList1.Images.SetKeyName(70, "gastos_por_zona.png")
        Me.ImageList1.Images.SetKeyName(71, "contabilidad.png")
        Me.ImageList1.Images.SetKeyName(72, "ajuste_de_contabilidad.png")
        Me.ImageList1.Images.SetKeyName(73, "ingreso_ventas.png")
        Me.ImageList1.Images.SetKeyName(74, "pendientes_problema.png")
        Me.ImageList1.Images.SetKeyName(75, "seguimiento_vendedor.png")
        Me.ImageList1.Images.SetKeyName(76, "cartera.png")
        Me.ImageList1.Images.SetKeyName(77, "pendientes.png")
        Me.ImageList1.Images.SetKeyName(78, "despachos.png")
        Me.ImageList1.Images.SetKeyName(79, "presupuesto_ventas.png")
        Me.ImageList1.Images.SetKeyName(80, "consultarp.png")
        Me.ImageList1.Images.SetKeyName(81, "presupuesto_recaudo.png")
        Me.ImageList1.Images.SetKeyName(82, "sac.png")
        Me.ImageList1.Images.SetKeyName(83, "quejas_y_reclamos.png")
        Me.ImageList1.Images.SetKeyName(84, "encuestas_clientes_nacionales.png")
        Me.ImageList1.Images.SetKeyName(85, "comisiones.png")
        Me.ImageList1.Images.SetKeyName(86, "reglas.png")
        Me.ImageList1.Images.SetKeyName(87, "liquidar_comisiones.png")
        Me.ImageList1.Images.SetKeyName(88, "gestion_de_documentacionp.png")
        Me.ImageList1.Images.SetKeyName(89, "logistica.png")
        Me.ImageList1.Images.SetKeyName(90, "relacion_factura_pedido_entrega.png")
        Me.ImageList1.Images.SetKeyName(91, "formato_impresion_etiquetas.png")
        Me.ImageList1.Images.SetKeyName(92, "gestionar_producto_no_conforme.png")
        Me.ImageList1.Images.SetKeyName(93, "traslado_de_la_B_2_a_la_3.png")
        Me.ImageList1.Images.SetKeyName(94, "produccion.png")
        Me.ImageList1.Images.SetKeyName(95, "calidad.png")
        Me.ImageList1.Images.SetKeyName(96, "recocido.png")
        Me.ImageList1.Images.SetKeyName(97, "ingreso_produccion.png")
        Me.ImageList1.Images.SetKeyName(98, "certificados_de_calidad.png")
        Me.ImageList1.Images.SetKeyName(99, "maestro_fichas_tecnicas.png")
        Me.ImageList1.Images.SetKeyName(100, "pendientes_produccion.png")
        Me.ImageList1.Images.SetKeyName(101, "historico_ventas.png")
        Me.ImageList1.Images.SetKeyName(102, "movimientos_inventario.png")
        Me.ImageList1.Images.SetKeyName(103, "modulo_traslados_de_bodega.png")
        Me.ImageList1.Images.SetKeyName(104, "gestionar_transacciones_sin_stock.png")
        Me.ImageList1.Images.SetKeyName(105, "traslados_de_bodega(handheld).png")
        Me.ImageList1.Images.SetKeyName(106, "maestro_transacion_handheld.png")
        Me.ImageList1.Images.SetKeyName(107, "mantenimiento.png")
        Me.ImageList1.Images.SetKeyName(108, "nuevos_repuestos.png")
        Me.ImageList1.Images.SetKeyName(109, "solicitud_de_correcion.png")
        Me.ImageList1.Images.SetKeyName(110, "presupuesto_de_produccion.png")
        Me.ImageList1.Images.SetKeyName(111, "informe_diferencia_trefilacion.png")
        Me.ImageList1.Images.SetKeyName(112, "presupuesto_de_gastos_y_articulos.png")
        Me.ImageList1.Images.SetKeyName(113, "presupuesto_de_articulos.png")
        Me.ImageList1.Images.SetKeyName(114, "presupuesto.png")
        Me.ImageList1.Images.SetKeyName(115, "gestionar_tornilleria.png")
        Me.ImageList1.Images.SetKeyName(116, "generar_tiquetes_terminado.png")
        Me.ImageList1.Images.SetKeyName(117, "consulta_planilla_separe.png")
        Me.ImageList1.Images.SetKeyName(118, "galvanizado.png")
        Me.ImageList1.Images.SetKeyName(119, "inventaios_fisicos.png")
        Me.ImageList1.Images.SetKeyName(120, "consulta_inventarios_fisicos.png")
        Me.ImageList1.Images.SetKeyName(121, "puntillerias.png")
        Me.ImageList1.Images.SetKeyName(122, "ambiental.png")
        Me.ImageList1.Images.SetKeyName(123, "gestionar_desperdicios.png")
        Me.ImageList1.Images.SetKeyName(124, "inventarios de metereologia.png")
        Me.ImageList1.Images.SetKeyName(125, "transacion_manual_DMS_SPIC.png")
        Me.ImageList1.Images.SetKeyName(126, "empaque_puntilleria.png")
        Me.ImageList1.Images.SetKeyName(127, "trazabilidad_de_transaciones.png")
        Me.ImageList1.Images.SetKeyName(128, "entradas_salidas_diarias.png")
        Me.ImageList1.Images.SetKeyName(129, "salida_materia_prima(2-11 y 11-2).png")
        Me.ImageList1.Images.SetKeyName(130, "orden_de_producion_galv.png")
        Me.ImageList1.Images.SetKeyName(131, "bobinas_detenidas.png")
        Me.ImageList1.Images.SetKeyName(132, "tiempo_trabajo.png")
        Me.ImageList1.Images.SetKeyName(133, "resumen_galvanizado.png")
        Me.ImageList1.Images.SetKeyName(134, "informe_de_paros.png")
        Me.ImageList1.Images.SetKeyName(135, "informe_estado_de_rollos.png")
        Me.ImageList1.Images.SetKeyName(136, "consulta.png")
        Me.ImageList1.Images.SetKeyName(137, "copia_tiquete_recocido.png")
        Me.ImageList1.Images.SetKeyName(138, "person.png")
        Me.ImageList1.Images.SetKeyName(139, "generar_tiquete_nc.png")
        Me.ImageList1.Images.SetKeyName(140, "limite_consumos_alambron.png")
        Me.ImageList1.Images.SetKeyName(141, "velocidades_de_codigos.png")
        Me.ImageList1.Images.SetKeyName(142, "actualizar_saldo_alambron.png")
        Me.ImageList1.Images.SetKeyName(143, "dias_de_vacaciones.png")
        Me.ImageList1.Images.SetKeyName(144, "compras.png")
        Me.ImageList1.Images.SetKeyName(145, "evaluaciones_de_proveedores.png")
        Me.ImageList1.Images.SetKeyName(146, "ordenes_de_compra.png")
        Me.ImageList1.Images.SetKeyName(147, "salidas_de_almacen.png")
        Me.ImageList1.Images.SetKeyName(148, "estupefacientes.png")
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.ItemHeight = 30
        Me.TreeView1.Location = New System.Drawing.Point(449, 28)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 31
        TreeNode1.Name = "nodMaestroPermiso"
        TreeNode1.SelectedImageIndex = 31
        TreeNode1.Text = "Maestro permisos"
        TreeNode2.ImageIndex = 32
        TreeNode2.Name = "nodMaestroModulo"
        TreeNode2.SelectedImageIndex = 32
        TreeNode2.Text = "Maestro módulos"
        TreeNode3.ImageIndex = 33
        TreeNode3.Name = "nodOpTransaccion"
        TreeNode3.SelectedImageIndex = 33
        TreeNode3.Text = "Maestro operaciones transacción"
        TreeNode4.ImageIndex = 30
        TreeNode4.Name = "Raiz_maestros"
        TreeNode4.SelectedImageIndex = 30
        TreeNode4.Text = "Maestros"
        TreeNode5.ImageIndex = 34
        TreeNode5.Name = "nodGestPermisos"
        TreeNode5.SelectedImageIndex = 34
        TreeNode5.Text = "Gestionar permisos"
        TreeNode6.ImageIndex = 35
        TreeNode6.Name = "nodMaeIpCorreos"
        TreeNode6.SelectedImageIndex = 35
        TreeNode6.Text = "Gestionar correo entrate y saliente"
        TreeNode7.ImageIndex = 36
        TreeNode7.Name = "nodAuditCambios"
        TreeNode7.SelectedImageIndex = 36
        TreeNode7.Text = "Auditoria de cambios"
        TreeNode8.ImageIndex = 37
        TreeNode8.Name = "nodGestUsu"
        TreeNode8.SelectedImageIndex = 37
        TreeNode8.Text = "Gestionar usuarios"
        TreeNode9.ImageIndex = 38
        TreeNode9.Name = "nodMaeCoordVend"
        TreeNode9.SelectedImageIndex = 38
        TreeNode9.Text = "Vendedores asociados a un coordinador"
        TreeNode10.ImageIndex = 39
        TreeNode10.Name = "nod_cerrar_por_ruta"
        TreeNode10.SelectedImageIndex = 39
        TreeNode10.Text = "Cerrar aplicaciones en una ruta"
        TreeNode11.ImageIndex = 40
        TreeNode11.Name = "nod_cerrar_for"
        TreeNode11.SelectedImageIndex = 40
        TreeNode11.Text = "Cerrar forzado"
        TreeNode12.ImageIndex = 41
        TreeNode12.Name = "nod_manual"
        TreeNode12.SelectedImageIndex = 41
        TreeNode12.Text = "Manuales"
        TreeNode13.ImageIndex = 42
        TreeNode13.Name = "nod_Acerca_de"
        TreeNode13.SelectedImageIndex = 42
        TreeNode13.Text = "Acerca de"
        TreeNode14.ImageIndex = 15
        TreeNode14.Name = "Raiz_config"
        TreeNode14.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode14.SelectedImageIndex = 15
        TreeNode14.Text = "Configuración"
        TreeNode15.ImageIndex = 45
        TreeNode15.Name = "nod_est_clien_vend"
        TreeNode15.SelectedImageIndex = 45
        TreeNode15.Text = "Estado client vend"
        TreeNode16.ImageIndex = 46
        TreeNode16.Name = "nod_info_clientes"
        TreeNode16.SelectedImageIndex = 46
        TreeNode16.Text = "Información clientes"
        TreeNode17.ImageIndex = 47
        TreeNode17.Name = "nod_Trazabilidad_clientes_atendidos"
        TreeNode17.SelectedImageIndex = 47
        TreeNode17.Text = "Trazabilidad clientes atendidos"
        TreeNode18.ImageIndex = 48
        TreeNode18.Name = "nod_super_modulo_consult_terceros"
        TreeNode18.SelectedImageIndex = 48
        TreeNode18.Text = "Super módulo de consulta de terceros"
        TreeNode19.ImageIndex = 44
        TreeNode19.Name = "Raiz_clientes"
        TreeNode19.SelectedImageIndex = 44
        TreeNode19.Text = "Clientes"
        TreeNode20.ImageIndex = 51
        TreeNode20.Name = "nod_an_pend"
        TreeNode20.SelectedImageIndex = 51
        TreeNode20.Text = "Análisis pendientes"
        TreeNode21.ImageIndex = 52
        TreeNode21.Name = "nod_audit_ped"
        TreeNode21.SelectedImageIndex = 52
        TreeNode21.Text = "Auditoria de pedidos"
        TreeNode22.ImageIndex = 53
        TreeNode22.Name = "nod_pend_zona"
        TreeNode22.SelectedImageIndex = 53
        TreeNode22.Text = "Pendientes por ruta"
        TreeNode23.ImageIndex = 54
        TreeNode23.Name = "nod_seg_pendientes"
        TreeNode23.SelectedImageIndex = 54
        TreeNode23.Text = "Seguimiento de pendientes"
        TreeNode24.ImageIndex = 48
        TreeNode24.Name = "nod_super_modulo_consult_pendientes"
        TreeNode24.SelectedImageIndex = 48
        TreeNode24.Text = "Super módulo de consulta(PENDIENTES)"
        TreeNode25.ImageIndex = 50
        TreeNode25.Name = "Raiz_pendientes"
        TreeNode25.SelectedImageIndex = 50
        TreeNode25.Text = "Pendientes"
        TreeNode26.ImageIndex = 56
        TreeNode26.Name = "nod_AnalisisVentas"
        TreeNode26.SelectedImageIndex = 56
        TreeNode26.Text = "Análisis de ventas por linea de producción"
        TreeNode27.ImageIndex = 57
        TreeNode27.Name = "nod_anali_vrKilo"
        TreeNode27.SelectedImageIndex = 57
        TreeNode27.Text = "Análisis valor kilo"
        TreeNode28.ImageIndex = 58
        TreeNode28.Name = "nod_acum_vtas"
        TreeNode28.SelectedImageIndex = 58
        TreeNode28.Text = "Acumulado ventas"
        TreeNode29.ImageIndex = 59
        TreeNode29.Name = "nod_acum_vtas_vend"
        TreeNode29.SelectedImageIndex = 59
        TreeNode29.Text = "Acum vtas vend"
        TreeNode30.ImageIndex = 60
        TreeNode30.Name = "nod_ppal_clientes"
        TreeNode30.SelectedImageIndex = 60
        TreeNode30.Text = "Principales clientes"
        TreeNode31.ImageIndex = 61
        TreeNode31.Name = "nodPrecProd"
        TreeNode31.SelectedImageIndex = 61
        TreeNode31.Text = "Precios por debajo de"
        TreeNode32.ImageIndex = 62
        TreeNode32.Name = "nod_correrias"
        TreeNode32.SelectedImageIndex = 62
        TreeNode32.Text = "Programacion correrias"
        TreeNode33.ImageIndex = 63
        TreeNode33.Name = "nod_vtas_client_idCor"
        TreeNode33.SelectedImageIndex = 63
        TreeNode33.Text = "Ventas cliente linea prod"
        TreeNode34.ImageIndex = 64
        TreeNode34.Name = "nod_Vtas_lin_ciuid"
        TreeNode34.SelectedImageIndex = 64
        TreeNode34.Text = "Ventas cliente por ciudad"
        TreeNode35.ImageIndex = 65
        TreeNode35.Name = "nod_vtas_clie_prod"
        TreeNode35.SelectedImageIndex = 65
        TreeNode35.Text = "Ventas client prod"
        TreeNode36.ImageIndex = 66
        TreeNode36.Name = "nod_vtas_zona"
        TreeNode36.SelectedImageIndex = 66
        TreeNode36.Text = "Ventas por zona"
        TreeNode37.ImageIndex = 47
        TreeNode37.Name = "nod_vtas_cliente_linea_mes"
        TreeNode37.SelectedImageIndex = 47
        TreeNode37.Text = "Ventas cliente linea de producción (por mes)"
        TreeNode38.ImageIndex = 48
        TreeNode38.Name = "nod_super_modulo_consult_vtas"
        TreeNode38.SelectedImageIndex = 48
        TreeNode38.Text = "Super módulo  de consultas(Ventas)"
        TreeNode39.ImageIndex = 55
        TreeNode39.Name = "Raiz_ventas"
        TreeNode39.SelectedImageIndex = 55
        TreeNode39.Text = "Ventas"
        TreeNode40.ImageIndex = 48
        TreeNode40.Name = "nod_super_modulo_consult_cartera"
        TreeNode40.SelectedImageIndex = 48
        TreeNode40.Text = "Super módulo  de consultas(Cartera)"
        TreeNode41.ImageIndex = 68
        TreeNode41.Name = "nod_fecha_venc_cartera"
        TreeNode41.SelectedImageIndex = 68
        TreeNode41.Text = "Fecha vencimiento cartera"
        TreeNode42.ImageIndex = 67
        TreeNode42.Name = "Raiz_cartera"
        TreeNode42.SelectedImageIndex = 67
        TreeNode42.Text = "Cartera"
        TreeNode43.ImageIndex = 48
        TreeNode43.Name = "nod_super_modulo_consult_recaudos"
        TreeNode43.SelectedImageIndex = 48
        TreeNode43.Text = "Super módulo  de consultas(Recaudos)"
        TreeNode44.ImageIndex = 69
        TreeNode44.Name = "Raiz_recaudos"
        TreeNode44.SelectedImageIndex = 69
        TreeNode44.Text = "Recaudos"
        TreeNode45.ImageIndex = 48
        TreeNode45.Name = "nod_super_modulo_consult_gastos_vendedor"
        TreeNode45.SelectedImageIndex = 48
        TreeNode45.Text = "Super módulo de consulta Costos por zona"
        TreeNode46.ImageIndex = 70
        TreeNode46.Name = "nod_gastos_zona_ventas"
        TreeNode46.SelectedImageIndex = 70
        TreeNode46.Text = "Gastos por zona"
        TreeNode47.ImageIndex = 72
        TreeNode47.Name = "nod_Ajus_Conts"
        TreeNode47.SelectedImageIndex = 72
        TreeNode47.Text = "Ajuste contabilidad"
        TreeNode48.ImageIndex = 71
        TreeNode48.Name = "nod_Conta_Menu"
        TreeNode48.SelectedImageIndex = 71
        TreeNode48.Text = "Contabilidad"
        TreeNode49.BackColor = System.Drawing.Color.Transparent
        TreeNode49.ForeColor = System.Drawing.Color.Black
        TreeNode49.ImageIndex = 49
        TreeNode49.Name = "Raiz_informes"
        TreeNode49.SelectedImageIndex = 49
        TreeNode49.Text = "Informes"
        TreeNode50.ImageIndex = 73
        TreeNode50.Name = "nod_ing_vtas"
        TreeNode50.SelectedImageIndex = 73
        TreeNode50.Text = "Ingreso ventas"
        TreeNode51.ImageIndex = 74
        TreeNode51.Name = "nod_pend_prob"
        TreeNode51.SelectedImageIndex = 74
        TreeNode51.Text = "Pendientes problema"
        TreeNode52.ImageIndex = 75
        TreeNode52.Name = "nod_seg_vend"
        TreeNode52.SelectedImageIndex = 75
        TreeNode52.Text = "Seg vendedor"
        TreeNode53.ImageIndex = 76
        TreeNode53.Name = "nod_cartera_ing_vtas"
        TreeNode53.SelectedImageIndex = 76
        TreeNode53.Text = "Cartera"
        TreeNode54.ImageIndex = 77
        TreeNode54.Name = "nod_pendientes_vend"
        TreeNode54.SelectedImageIndex = 77
        TreeNode54.Text = "Pendientes"
        TreeNode55.ImageIndex = 78
        TreeNode55.Name = "nod_despachos"
        TreeNode55.SelectedImageIndex = 78
        TreeNode55.Text = "Despachos"
        TreeNode56.Name = "nodIngVtasMovil"
        TreeNode56.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode56.Text = "Movil"
        TreeNode57.ImageIndex = 73
        TreeNode57.Name = "Raiz_ing_vtas"
        TreeNode57.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode57.SelectedImageIndex = 73
        TreeNode57.Text = "Ingreso ventas"
        TreeNode58.ImageIndex = 80
        TreeNode58.Name = "nod_consult_ppto_vtas"
        TreeNode58.SelectedImageIndex = 80
        TreeNode58.Text = "Consultar"
        TreeNode59.ImageIndex = 79
        TreeNode59.Name = "nod_ppto_vtas"
        TreeNode59.SelectedImageIndex = 79
        TreeNode59.Text = "Presupuesto ventas"
        TreeNode60.ImageIndex = 79
        TreeNode60.Name = "Raiz_ppto_vtas"
        TreeNode60.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode60.SelectedImageIndex = 79
        TreeNode60.Text = "Presupuesto ventas"
        TreeNode61.ImageIndex = 80
        TreeNode61.Name = "nod_consul_ppto_rec"
        TreeNode61.SelectedImageIndex = 80
        TreeNode61.Text = "Consultar ppto rec"
        TreeNode62.ImageIndex = 81
        TreeNode62.Name = "nod_ppto_rec"
        TreeNode62.SelectedImageIndex = 81
        TreeNode62.Text = "Presupuesto de recaudo"
        TreeNode63.ImageIndex = 81
        TreeNode63.Name = "Raiz_ppto_rec"
        TreeNode63.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode63.SelectedImageIndex = 81
        TreeNode63.Text = "Presupuesto recaudo"
        TreeNode64.ImageIndex = 47
        TreeNode64.Name = "nod_seg_vend"
        TreeNode64.SelectedImageIndex = 47
        TreeNode64.Text = "Seg vendedores"
        TreeNode65.ImageIndex = 75
        TreeNode65.Name = "nod_seg_ppto"
        TreeNode65.SelectedImageIndex = 75
        TreeNode65.Text = "Seg presupuesto"
        TreeNode66.ImageIndex = 75
        TreeNode66.Name = "nod_seg_grupos"
        TreeNode66.SelectedImageIndex = 75
        TreeNode66.Text = "Seg Lineas"
        TreeNode67.ImageIndex = 36
        TreeNode67.Name = "nod_anticipos"
        TreeNode67.SelectedImageIndex = 36
        TreeNode67.Text = "Anticipos"
        TreeNode68.ImageIndex = 48
        TreeNode68.Name = "nod_seguimiento_ppto_mes"
        TreeNode68.SelectedImageIndex = 48
        TreeNode68.Text = "Seguimiento de presupuestos (MES)"
        TreeNode69.ImageIndex = 47
        TreeNode69.Name = "Raiz_nod_seg_vend"
        TreeNode69.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode69.SelectedImageIndex = 47
        TreeNode69.Text = "Seguimiento vendedores"
        TreeNode70.ImageIndex = 83
        TreeNode70.Name = "nodQuejasRec"
        TreeNode70.SelectedImageIndex = 83
        TreeNode70.Text = "Quejas y reclamos"
        TreeNode71.ImageIndex = 84
        TreeNode71.Name = "nod_encu_clientes"
        TreeNode71.SelectedImageIndex = 84
        TreeNode71.Text = "Encuesta clientes nacionales"
        TreeNode72.ImageIndex = 80
        TreeNode72.Name = "nod_consult_encuesta_cliente"
        TreeNode72.SelectedImageIndex = 80
        TreeNode72.Text = "Consultar encuestas"
        TreeNode72.ToolTipText = "Consultar encuestas"
        TreeNode73.ImageIndex = 82
        TreeNode73.Name = "RaizSac"
        TreeNode73.SelectedImageIndex = 82
        TreeNode73.Text = "SAC"
        TreeNode74.ImageIndex = 86
        TreeNode74.Name = "nod_reglas_comisiones"
        TreeNode74.SelectedImageIndex = 86
        TreeNode74.Text = "Reglas"
        TreeNode75.ImageIndex = 87
        TreeNode75.Name = "nod_liquidacion_com"
        TreeNode75.SelectedImageIndex = 87
        TreeNode75.Text = "Liquidar comisiones (informe)"
        TreeNode76.ImageIndex = 85
        TreeNode76.Name = "Raiz_comisiones"
        TreeNode76.SelectedImageIndex = 85
        TreeNode76.Text = "Comisiones"
        TreeNode77.ImageIndex = 36
        TreeNode77.Name = "nod_cambio_cliente_vendedor"
        TreeNode77.SelectedImageIndex = 36
        TreeNode77.Text = "Cambiar Cart-Pend-Terceros de vendedor"
        TreeNode78.ImageIndex = 15
        TreeNode78.Name = "Raiz_administrar_cambios"
        TreeNode78.SelectedImageIndex = 15
        TreeNode78.Text = "Admisnistrar cambios"
        TreeNode79.ImageIndex = 88
        TreeNode79.Name = "nod_gest_doc"
        TreeNode79.SelectedImageIndex = 88
        TreeNode79.Text = "Gestion de Documentación"
        TreeNode80.ImageIndex = 43
        TreeNode80.Name = "Raiz_ofic"
        TreeNode80.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode80.SelectedImageIndex = 43
        TreeNode80.Text = "Oficinas"
        TreeNode81.ImageIndex = 123
        TreeNode81.Name = "nod_gest_desperdicios"
        TreeNode81.SelectedImageIndex = 123
        TreeNode81.Text = "Gestionar desperdicios"
        TreeNode82.ImageIndex = 124
        TreeNode82.Name = "nod_inv_metrologia"
        TreeNode82.SelectedImageIndex = 124
        TreeNode82.Text = "Inventarios de metrología"
        TreeNode83.ImageIndex = 122
        TreeNode83.Name = "Raiz_ambiental"
        TreeNode83.SelectedImageIndex = 122
        TreeNode83.Text = "Ambiental"
        TreeNode84.ImageIndex = 96
        TreeNode84.Name = "nod_recocido_calidad"
        TreeNode84.SelectedImageIndex = 96
        TreeNode84.Text = "Recocido"
        TreeNode85.ImageIndex = 149
        TreeNode85.Name = "nod_reporte_inspeccion_calidad"
        TreeNode85.SelectedImageIndex = 149
        TreeNode85.Text = "Reporte Inspeccion calidad"
        TreeNode86.ImageIndex = 95
        TreeNode86.Name = "Raiz_calidad"
        TreeNode86.SelectedImageIndex = 95
        TreeNode86.Text = "Calidad"
        TreeNode87.ImageIndex = 97
        TreeNode87.Name = "nod_ing_punt"
        TreeNode87.SelectedImageIndex = 97
        TreeNode87.Text = "Puntilleria"
        TreeNode88.ImageIndex = 97
        TreeNode88.Name = "nod_ing_puas"
        TreeNode88.SelectedImageIndex = 97
        TreeNode88.Text = "Púas"
        TreeNode89.ImageIndex = 97
        TreeNode89.Name = "nod_ing_galv"
        TreeNode89.SelectedImageIndex = 97
        TreeNode89.Text = "Galvanizado(forma1)solo consultas"
        TreeNode90.ImageIndex = 97
        TreeNode90.Name = "nod_galv_f2"
        TreeNode90.SelectedImageIndex = 97
        TreeNode90.Text = "Galvanizado (forma2)"
        TreeNode91.ImageIndex = 97
        TreeNode91.Name = "nodTref3"
        TreeNode91.SelectedImageIndex = 97
        TreeNode91.Text = "Trefilación (Forma 2)"
        TreeNode92.ImageIndex = 97
        TreeNode92.Name = "nod_tref_forma3"
        TreeNode92.SelectedImageIndex = 97
        TreeNode92.Text = "Trefilación (Forma 3)"
        TreeNode93.ImageIndex = 97
        TreeNode93.Name = "nodPulimiento"
        TreeNode93.SelectedImageIndex = 97
        TreeNode93.Text = "Pulimiento(tambores)"
        TreeNode94.ImageIndex = 97
        TreeNode94.Name = "nod_galv_baches"
        TreeNode94.SelectedImageIndex = 97
        TreeNode94.Text = "Galvanizado por baches"
        TreeNode95.ImageIndex = 97
        TreeNode95.Name = "nod_recocido"
        TreeNode95.SelectedImageIndex = 97
        TreeNode95.Text = "Recocido"
        TreeNode96.ImageIndex = 97
        TreeNode96.Name = "nod_IngTornilleria"
        TreeNode96.SelectedImageIndex = 97
        TreeNode96.Text = "Tornilleria"
        TreeNode97.ImageIndex = 97
        TreeNode97.Name = "nod_temple"
        TreeNode97.SelectedImageIndex = 97
        TreeNode97.Text = "Tratamientos termicos (Temple)"
        TreeNode98.ImageIndex = 126
        TreeNode98.Name = "nod_empaque_puntilleria"
        TreeNode98.SelectedImageIndex = 126
        TreeNode98.Text = "Empaque de puntilleria"
        TreeNode99.ImageIndex = 125
        TreeNode99.Name = "nodTranManDmsSpic"
        TreeNode99.SelectedImageIndex = 125
        TreeNode99.Text = "Transacción manual DMS-SPIC"
        TreeNode100.ImageIndex = 97
        TreeNode100.Name = "Raiz_ing_prod"
        TreeNode100.SelectedImageIndex = 97
        TreeNode100.Text = "Ingreso de producción"
        TreeNode101.ImageIndex = 5
        TreeNode101.Name = "nod_consultar_certificados"
        TreeNode101.SelectedImageIndex = 5
        TreeNode101.Text = "Consultar certificados historicos"
        TreeNode102.ImageIndex = 98
        TreeNode102.Name = "nodGenFichasYcertf"
        TreeNode102.SelectedImageIndex = 98
        TreeNode102.Text = "Generar certificado de calidad"
        TreeNode103.ImageIndex = 99
        TreeNode103.Name = "nod_maestro_fichas"
        TreeNode103.SelectedImageIndex = 99
        TreeNode103.Text = "Maestro fichas técnicas"
        TreeNode104.ImageIndex = 98
        TreeNode104.Name = "Raiz_certf_calidad"
        TreeNode104.SelectedImageIndex = 98
        TreeNode104.Text = "Certificados de calidad"
        TreeNode105.ImageIndex = 100
        TreeNode105.Name = "nod_pend_prod"
        TreeNode105.SelectedImageIndex = 100
        TreeNode105.Text = "Pendientes producción"
        TreeNode106.ImageIndex = 101
        TreeNode106.Name = "nod_traz_vtas_linea"
        TreeNode106.SelectedImageIndex = 101
        TreeNode106.Text = "Historico ventas"
        TreeNode107.ImageIndex = 102
        TreeNode107.Name = "nod_aud_inv"
        TreeNode107.SelectedImageIndex = 102
        TreeNode107.Text = "Movimiento inventario"
        TreeNode108.Name = "nod_eficiencias"
        TreeNode108.Text = "Eficiencias"
        TreeNode109.ImageIndex = 5
        TreeNode109.Name = "nodTransDms"
        TreeNode109.SelectedImageIndex = 5
        TreeNode109.Text = "Consultar transacciones Dms"
        TreeNode110.ImageIndex = 127
        TreeNode110.Name = "nod_trazabilidad_transacciones"
        TreeNode110.SelectedImageIndex = 127
        TreeNode110.Text = "Trazabilidad de transacciones"
        TreeNode111.ImageIndex = 127
        TreeNode111.Name = "nod_maximos_minimos"
        TreeNode111.SelectedImageIndex = 127
        TreeNode111.Text = "Informe de máximos y minimos"
        TreeNode112.ImageIndex = 127
        TreeNode112.Name = "nod_entradas_salidas_ref"
        TreeNode112.SelectedImageIndex = 127
        TreeNode112.Text = "Entradas-salidas-inventarios"
        TreeNode113.ImageIndex = 128
        TreeNode113.Name = "nod_entradas_salidas_diarias"
        TreeNode113.SelectedImageIndex = 128
        TreeNode113.Text = "Entradas_salidas_DIARIO"
        TreeNode114.ImageIndex = 49
        TreeNode114.Name = "Raiz_informes_prod"
        TreeNode114.SelectedImageIndex = 49
        TreeNode114.Text = "Informes"
        TreeNode115.ImageIndex = 104
        TreeNode115.Name = "nod_GestTransaSinStock"
        TreeNode115.SelectedImageIndex = 104
        TreeNode115.Text = "Gestionar transacciones sin stock"
        TreeNode116.ImageIndex = 105
        TreeNode116.Name = "nod_tras_bod_hand"
        TreeNode116.SelectedImageIndex = 105
        TreeNode116.Text = "Traslado de bodega (handheld)"
        TreeNode117.ImageIndex = 106
        TreeNode117.Name = "nod_MaestroTransHandHeld"
        TreeNode117.SelectedImageIndex = 106
        TreeNode117.Text = "Maestro Transaccion HandHeld"
        TreeNode118.ImageIndex = 103
        TreeNode118.Name = "Raiz_traslado_bodega"
        TreeNode118.SelectedImageIndex = 103
        TreeNode118.Text = "Módulo traslados de bodega"
        TreeNode119.ImageIndex = 108
        TreeNode119.Name = "nodMaeRepuestos"
        TreeNode119.SelectedImageIndex = 108
        TreeNode119.Text = "Nuevos repuestos"
        TreeNode120.ImageIndex = 109
        TreeNode120.Name = "nodCorreccion"
        TreeNode120.SelectedImageIndex = 109
        TreeNode120.Text = "Solicitud de correción"
        TreeNode121.ImageIndex = 107
        TreeNode121.Name = "RaizMantenimiento"
        TreeNode121.SelectedImageIndex = 107
        TreeNode121.Text = "Mantenimiento"
        TreeNode122.ImageIndex = 110
        TreeNode122.Name = "nod_ppto_produccion"
        TreeNode122.SelectedImageIndex = 110
        TreeNode122.Text = "Presupuesto de producción"
        TreeNode123.ImageIndex = 127
        TreeNode123.Name = "nod_seg_ppto_produccion"
        TreeNode123.SelectedImageIndex = 127
        TreeNode123.Text = "Seguimiento de presupuesto de producción"
        TreeNode124.ImageIndex = 111
        TreeNode124.Name = "nod_dif_pes_tref"
        TreeNode124.SelectedImageIndex = 111
        TreeNode124.Text = "Informe Diferencia Trefilacion"
        TreeNode125.ImageIndex = 110
        TreeNode125.Name = "Raiz_ppto_produccion"
        TreeNode125.SelectedImageIndex = 110
        TreeNode125.Text = "Presupuesto de producción"
        TreeNode126.ImageIndex = 113
        TreeNode126.Name = "nod_ppto_articulos"
        TreeNode126.SelectedImageIndex = 113
        TreeNode126.Text = "Presupuesto de articulos"
        TreeNode127.ImageIndex = 113
        TreeNode127.Name = "Raiz_ppto_articulos"
        TreeNode127.SelectedImageIndex = 113
        TreeNode127.Text = "Presupuesto de articulos"
        TreeNode128.ImageIndex = 114
        TreeNode128.Name = "nod_ppto_gastos"
        TreeNode128.SelectedImageIndex = 114
        TreeNode128.Text = "Presupuesto"
        TreeNode129.ImageIndex = 127
        TreeNode129.Name = "nod_seg_ppto_gastos"
        TreeNode129.SelectedImageIndex = 127
        TreeNode129.Text = "Seguimiento presupuesto de gastos y articulos"
        TreeNode130.ImageIndex = 112
        TreeNode130.Name = "Raiz_ppto_gastos"
        TreeNode130.SelectedImageIndex = 112
        TreeNode130.Text = "Presupuesto de gastos y articulos"
        TreeNode131.ImageIndex = 116
        TreeNode131.Name = "nod_generar_tiquetes_terminado"
        TreeNode131.SelectedImageIndex = 116
        TreeNode131.Text = "Generar tiquetes terminado"
        TreeNode132.ImageIndex = 117
        TreeNode132.Name = "nod_consultar_separe"
        TreeNode132.SelectedImageIndex = 117
        TreeNode132.Text = "Consultar planilla separe"
        TreeNode133.ImageIndex = 115
        TreeNode133.Name = "Raiz_gestionar_tornilleria"
        TreeNode133.SelectedImageIndex = 115
        TreeNode133.Text = "Gestionar tornilleria"
        TreeNode134.ImageIndex = 129
        TreeNode134.Name = "nod_salida_materia_prima_G"
        TreeNode134.SelectedImageIndex = 129
        TreeNode134.Text = "Salida materia de prima (2-11 y 11-2)"
        TreeNode135.ImageIndex = 136
        TreeNode135.Name = "nod_consulta_materia_prima_G"
        TreeNode135.SelectedImageIndex = 136
        TreeNode135.Text = "Consulta materia prima (2-11 y 11-2)"
        TreeNode136.ImageIndex = 130
        TreeNode136.Name = "nod_Orden_produccion_Galvanizado"
        TreeNode136.SelectedImageIndex = 130
        TreeNode136.Text = "Orden de produción galv"
        TreeNode137.ImageIndex = 49
        TreeNode137.Name = "nod_Informe_produccion_Galvanizado"
        TreeNode137.SelectedImageIndex = 49
        TreeNode137.Text = "Informe producción galvanizado"
        TreeNode138.ImageIndex = 135
        TreeNode138.Name = "nod_Informe_estado_rollos"
        TreeNode138.SelectedImageIndex = 135
        TreeNode138.Text = "Informe estado de rollos"
        TreeNode139.ImageIndex = 131
        TreeNode139.Name = "nod_Informe_bobinas_paradas"
        TreeNode139.SelectedImageIndex = 131
        TreeNode139.Text = "Bobinas detenidas"
        TreeNode140.ImageIndex = 132
        TreeNode140.Name = "nod_Informe_tiempo_trabajo"
        TreeNode140.SelectedImageIndex = 132
        TreeNode140.Text = "Tiempo trabajo"
        TreeNode141.ImageIndex = 133
        TreeNode141.Name = "nod_Informe_resumen_galvanizado"
        TreeNode141.SelectedImageIndex = 133
        TreeNode141.Text = "Resumen galvanizado"
        TreeNode142.ImageIndex = 134
        TreeNode142.Name = "nod_paros_galv"
        TreeNode142.SelectedImageIndex = 134
        TreeNode142.Text = "Informe de paros"
        TreeNode143.ImageIndex = 118
        TreeNode143.Name = "nodGalvanizado"
        TreeNode143.SelectedImageIndex = 118
        TreeNode143.Text = "Galvanizado"
        TreeNode144.ImageIndex = 119
        TreeNode144.Name = "nod_consult_inv_fisicos"
        TreeNode144.SelectedImageIndex = 119
        TreeNode144.Text = "Consultar inventarios fisicos"
        TreeNode145.ImageIndex = 127
        TreeNode145.Name = "nod_auditoria_inventario"
        TreeNode145.SelectedImageIndex = 127
        TreeNode145.Text = "Auditoria Inventario"
        TreeNode146.ImageIndex = 119
        TreeNode146.Name = "Raiz_nventarios_fisicos"
        TreeNode146.SelectedImageIndex = 119
        TreeNode146.Text = "Inventarios fisicos"
        TreeNode147.ImageIndex = 35
        TreeNode147.Name = "nod_solicitud_mp_puntilleria"
        TreeNode147.SelectedImageIndex = 35
        TreeNode147.Text = "Solicitar materia prima"
        TreeNode148.ImageIndex = 5
        TreeNode148.Name = "nod_consult_solicitud_mp_punt"
        TreeNode148.SelectedImageIndex = 5
        TreeNode148.Text = "Consultar solicitudes"
        TreeNode149.ImageIndex = 130
        TreeNode149.Name = "nod_orden_prod_punt"
        TreeNode149.SelectedImageIndex = 130
        TreeNode149.Text = "Orden de producción"
        TreeNode150.ImageIndex = 127
        TreeNode150.Name = "nod_auditoria_puntilleria"
        TreeNode150.SelectedImageIndex = 127
        TreeNode150.Text = "Auditoria Puntilleria"
        TreeNode151.ImageIndex = 121
        TreeNode151.Name = "Raiz_puntilleria"
        TreeNode151.SelectedImageIndex = 121
        TreeNode151.Text = "Puntilleria"
        TreeNode152.ImageIndex = 35
        TreeNode152.Name = "nod_solicitud_mp_recocido"
        TreeNode152.SelectedImageIndex = 35
        TreeNode152.Text = "Solicitar materia prima"
        TreeNode153.ImageIndex = 5
        TreeNode153.Name = "nod_consult_solicitud_mp_recocido"
        TreeNode153.SelectedImageIndex = 5
        TreeNode153.Text = "Consultar solicitudes"
        TreeNode154.ImageIndex = 130
        TreeNode154.Name = "nod_orden_produccion_rec"
        TreeNode154.SelectedImageIndex = 130
        TreeNode154.Text = "Orden de produccion Recocido"
        TreeNode155.ImageIndex = 127
        TreeNode155.Name = "nod_auditoria_recocido"
        TreeNode155.SelectedImageIndex = 127
        TreeNode155.Text = "Auditoria Recocido"
        TreeNode156.ImageIndex = 127
        TreeNode156.Name = "nod_auditoria_tref_rec"
        TreeNode156.SelectedImageIndex = 127
        TreeNode156.Text = "Auditoria Tref-Rec"
        TreeNode157.ImageIndex = 137
        TreeNode157.Name = "nod_tiquete_rec_manual"
        TreeNode157.SelectedImageIndex = 137
        TreeNode157.Text = "Copia tiquete recocido"
        TreeNode158.ImageIndex = 92
        TreeNode158.Name = "nod_tiquete_nc"
        TreeNode158.SelectedImageIndex = 92
        TreeNode158.Text = "Tiquete no conforme"
        TreeNode159.ImageIndex = 96
        TreeNode159.Name = "Raiz_Recocido"
        TreeNode159.SelectedImageIndex = 96
        TreeNode159.Text = "Recocido"
        TreeNode160.ImageIndex = 35
        TreeNode160.Name = "nod_solicitud_mp_puas"
        TreeNode160.SelectedImageIndex = 35
        TreeNode160.Text = "Solicitar materia prima"
        TreeNode161.ImageIndex = 5
        TreeNode161.Name = "nod_consult_solicitud_mp_puas"
        TreeNode161.SelectedImageIndex = 5
        TreeNode161.Text = "Consultar solicitudes"
        TreeNode162.ImageIndex = 130
        TreeNode162.Name = "nod_orden_prod_puas"
        TreeNode162.SelectedImageIndex = 130
        TreeNode162.Text = "Orden de producción operario"
        TreeNode163.ImageIndex = 120
        TreeNode163.Name = "nod_crear_orden_puas"
        TreeNode163.SelectedImageIndex = 120
        TreeNode163.Text = "Crear orden puas"
        TreeNode164.ImageIndex = 71
        TreeNode164.Name = "nod_prod_puas"
        TreeNode164.SelectedImageIndex = 71
        TreeNode164.Text = "Producción de puas"
        TreeNode165.ImageIndex = 134
        TreeNode165.Name = "nod_infor_paros_puas"
        TreeNode165.SelectedImageIndex = 134
        TreeNode165.Text = "Informe de paros púas"
        TreeNode166.ImageIndex = 118
        TreeNode166.Name = "raiz_puas"
        TreeNode166.SelectedImageIndex = 118
        TreeNode166.Text = "Alambre de Puas"
        TreeNode167.ImageIndex = 69
        TreeNode167.Name = "nod_proyectos"
        TreeNode167.SelectedImageIndex = 69
        TreeNode167.Text = "Crear proyecto"
        TreeNode168.ImageIndex = 136
        TreeNode168.Name = "nod_consultar_proyecto"
        TreeNode168.SelectedImageIndex = 136
        TreeNode168.Text = "Consultar proyectos"
        TreeNode169.ImageIndex = 127
        TreeNode169.Name = "Raiz_proyectos"
        TreeNode169.SelectedImageIndex = 127
        TreeNode169.Text = "Gestionar proyectos"
        TreeNode170.ImageIndex = 138
        TreeNode170.Name = "nod_solicitud_scal"
        TreeNode170.SelectedImageIndex = 138
        TreeNode170.Text = "Solicitud scal"
        TreeNode171.ImageIndex = 138
        TreeNode171.Name = "nod_solicitud_scae"
        TreeNode171.SelectedImageIndex = 138
        TreeNode171.Text = "Solicitud scae"
        TreeNode172.ImageIndex = 138
        TreeNode172.Name = "nod_solicitud_sar"
        TreeNode172.SelectedImageIndex = 138
        TreeNode172.Text = "Solicitud sar"
        TreeNode173.ImageIndex = 138
        TreeNode173.Name = "nod_solicitud_sav"
        TreeNode173.SelectedImageIndex = 138
        TreeNode173.Text = "Solicitud sav"
        TreeNode174.ImageIndex = 136
        TreeNode174.Name = "nod_consulta_scal"
        TreeNode174.SelectedImageIndex = 136
        TreeNode174.Text = "Consulta de pedidos scal"
        TreeNode175.ImageIndex = 136
        TreeNode175.Name = "nod_consulta_scae"
        TreeNode175.SelectedImageIndex = 136
        TreeNode175.Text = "Consulta de pedidos scae"
        TreeNode176.ImageIndex = 136
        TreeNode176.Name = "nod_consulta_sar"
        TreeNode176.SelectedImageIndex = 136
        TreeNode176.Text = "Consulta de pedidos sar"
        TreeNode177.ImageIndex = 136
        TreeNode177.Name = "nod_consulta_sav"
        TreeNode177.SelectedImageIndex = 136
        TreeNode177.Text = "Consulta de pedidos sav"
        TreeNode178.ImageIndex = 138
        TreeNode178.Name = "nod_scal_scae_sav"
        TreeNode178.SelectedImageIndex = 138
        TreeNode178.Text = "Consumos scal,scae,sar y sav"
        TreeNode179.ImageIndex = 130
        TreeNode179.Name = "nodOrdenProd"
        TreeNode179.SelectedImageIndex = 130
        TreeNode179.Text = "Ordenes de producción"
        TreeNode180.ImageIndex = 127
        TreeNode180.Name = "nod_auditoria_alambres"
        TreeNode180.SelectedImageIndex = 127
        TreeNode180.Text = "Auditoria de alambres"
        TreeNode181.ImageIndex = 139
        TreeNode181.Name = "nod_gen_tiquet_tref"
        TreeNode181.SelectedImageIndex = 139
        TreeNode181.Text = "Generar tiquete tref NC"
        TreeNode182.ImageIndex = 94
        TreeNode182.Name = "nodGesRef"
        TreeNode182.SelectedImageIndex = 94
        TreeNode182.Text = "Gestionar linea de producción"
        TreeNode183.ImageIndex = 125
        TreeNode183.Name = "nod_limite_consumos"
        TreeNode183.SelectedImageIndex = 125
        TreeNode183.Text = "Limite consumos alambron"
        TreeNode184.ImageIndex = 141
        TreeNode184.Name = "nod_cod_vel"
        TreeNode184.SelectedImageIndex = 141
        TreeNode184.Text = "Velocidades de codigos"
        TreeNode185.ImageIndex = 114
        TreeNode185.Name = "nod_sal_alam"
        TreeNode185.SelectedImageIndex = 114
        TreeNode185.Text = "Saldo alambron"
        TreeNode186.ImageIndex = 142
        TreeNode186.Name = "nod_act_alam"
        TreeNode186.SelectedImageIndex = 142
        TreeNode186.Text = "Actualizar alambron"
        TreeNode187.ImageIndex = 136
        TreeNode187.Name = "nod_tref_form3"
        TreeNode187.SelectedImageIndex = 136
        TreeNode187.Text = "Consulta tref forma 3"
        TreeNode188.ImageIndex = 118
        TreeNode188.Name = "nod_tref_com"
        TreeNode188.SelectedImageIndex = 118
        TreeNode188.Text = "Trefilación"
        TreeNode189.ImageIndex = 115
        TreeNode189.Name = "nod_cosnu_tornilleria"
        TreeNode189.SelectedImageIndex = 115
        TreeNode189.Text = "Consumo de tornileria"
        TreeNode190.ImageIndex = 115
        TreeNode190.Name = "nod_Mod_Tornilleria"
        TreeNode190.SelectedImageIndex = 115
        TreeNode190.Text = "Tornilleria"
        TreeNode191.ImageIndex = 138
        TreeNode191.Name = "nod_mat_consumida"
        TreeNode191.SelectedImageIndex = 138
        TreeNode191.Text = "consumo y producción de tref"
        TreeNode192.ImageIndex = 138
        TreeNode192.Name = "nod_mat_punt"
        TreeNode192.SelectedImageIndex = 138
        TreeNode192.Text = "consumo y producción de punt"
        TreeNode193.ImageIndex = 138
        TreeNode193.Name = "nod_mat_galv"
        TreeNode193.SelectedImageIndex = 138
        TreeNode193.Text = "consumo y produccion galv"
        TreeNode194.ImageIndex = 138
        TreeNode194.Name = "nod_segui_consu"
        TreeNode194.SelectedImageIndex = 138
        TreeNode194.Text = "Seguimiento de consumos"
        TreeNode195.ImageIndex = 142
        TreeNode195.Name = "nod_cambiar_centro"
        TreeNode195.SelectedImageIndex = 142
        TreeNode195.Text = "Cambiar centro (Planta)"
        TreeNode196.ImageIndex = 127
        TreeNode196.Name = "nod_auditoria"
        TreeNode196.SelectedImageIndex = 127
        TreeNode196.Text = "Auditoria"
        TreeNode197.ImageIndex = 94
        TreeNode197.Name = "Raiz_prod"
        TreeNode197.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode197.SelectedImageIndex = 94
        TreeNode197.Text = "Producción"
        TreeNode198.ImageIndex = 138
        TreeNode198.Name = "nod_info_dane"
        TreeNode198.SelectedImageIndex = 138
        TreeNode198.Text = "Informe personal Dane"
        TreeNode199.ImageIndex = 138
        TreeNode199.Name = "nod_informe_pers_activo"
        TreeNode199.SelectedImageIndex = 138
        TreeNode199.Text = "Informe Personal Activo"
        TreeNode200.ImageIndex = 138
        TreeNode200.Name = "nod_info_empleados"
        TreeNode200.SelectedImageIndex = 138
        TreeNode200.Text = "Información de empleados"
        TreeNode201.ImageIndex = 137
        TreeNode201.Name = "nod_informe_ausentismos"
        TreeNode201.SelectedImageIndex = 137
        TreeNode201.Text = "Informe de incapacidades y ausentismos"
        TreeNode202.ImageIndex = 143
        TreeNode202.Name = "nod_dias_vacaciones"
        TreeNode202.SelectedImageIndex = 143
        TreeNode202.Text = "Días de vacaciones"
        TreeNode203.ImageIndex = 132
        TreeNode203.Name = "nod_tiempos_laborados"
        TreeNode203.SelectedImageIndex = 132
        TreeNode203.Text = "Tiempos laborados"
        TreeNode204.ImageIndex = 142
        TreeNode204.Name = "nod_rotacion_personal"
        TreeNode204.SelectedImageIndex = 142
        TreeNode204.Text = "Rotación del personal"
        TreeNode205.ImageIndex = 45
        TreeNode205.Name = "nodReg_personal_maquila"
        TreeNode205.SelectedImageIndex = 45
        TreeNode205.Text = "Registrar personal maquilas"
        TreeNode206.ImageIndex = 137
        TreeNode206.Name = "nod_informe_temporales"
        TreeNode206.SelectedImageIndex = 137
        TreeNode206.Text = "Informe temporales"
        TreeNode207.ImageIndex = 45
        TreeNode207.Name = "Raiz maquila"
        TreeNode207.SelectedImageIndex = 45
        TreeNode207.Text = "Personal maquilas"
        TreeNode208.ImageIndex = 141
        TreeNode208.Name = "nod_liqui_reloj"
        TreeNode208.SelectedImageIndex = 141
        TreeNode208.Text = "Procesar marcaciones"
        TreeNode209.ImageIndex = 71
        TreeNode209.Name = "nod_programacion_turnos"
        TreeNode209.SelectedImageIndex = 71
        TreeNode209.Text = "Programación de turnos"
        TreeNode210.ImageIndex = 107
        TreeNode210.Name = "nod_MaePeriodos"
        TreeNode210.SelectedImageIndex = 107
        TreeNode210.Text = "Gestionar periodos de corte de novedades"
        TreeNode211.ImageIndex = 127
        TreeNode211.Name = "nod_informe_marcaciones"
        TreeNode211.SelectedImageIndex = 127
        TreeNode211.Text = "Informe de inconsistencia en marcaciones"
        TreeNode212.ImageIndex = 71
        TreeNode212.Name = "Nod_consult_compromisos"
        TreeNode212.SelectedImageIndex = 71
        TreeNode212.Text = "Consultar compromisos"
        TreeNode213.ImageIndex = 71
        TreeNode213.Name = "nod_informe_nov_pendientes"
        TreeNode213.SelectedImageIndex = 71
        TreeNode213.Text = "Informe de novedades pendientes"
        TreeNode214.ImageIndex = 138
        TreeNode214.Name = "nod_per_activo"
        TreeNode214.SelectedImageIndex = 138
        TreeNode214.Text = "Personal en Corsan"
        TreeNode215.ImageIndex = 132
        TreeNode215.Name = "Raiz_reloj"
        TreeNode215.SelectedImageIndex = 132
        TreeNode215.Text = "Reloj"
        TreeNode216.ImageIndex = 125
        TreeNode216.Name = "nod_evaluacione_desempeno"
        TreeNode216.SelectedImageIndex = 125
        TreeNode216.Text = "Evaluacion de desempeño"
        TreeNode217.ImageIndex = 136
        TreeNode217.Name = "nod_consultar_eval_desempeno"
        TreeNode217.SelectedImageIndex = 136
        TreeNode217.Text = "Consultar evaluaciónes de desempeño"
        TreeNode218.ImageIndex = 52
        TreeNode218.Name = "nod_permisos_evaluaciones"
        TreeNode218.SelectedImageIndex = 52
        TreeNode218.Text = "Permisos evaluaciones"
        TreeNode219.ImageIndex = 125
        TreeNode219.Name = "Raiz_eval_desempeno"
        TreeNode219.SelectedImageIndex = 125
        TreeNode219.Text = "Evaluaciones de desempeño"
        TreeNode220.ImageIndex = 34
        TreeNode220.Name = "nod_buzon_sugerencias_det"
        TreeNode220.SelectedImageIndex = 34
        TreeNode220.Text = "Buzon de Sugerencias"
        TreeNode221.ImageIndex = 52
        TreeNode221.Name = "nod_buzon_cons_premios"
        TreeNode221.SelectedImageIndex = 52
        TreeNode221.Text = "Consulta Solicitud de Premios"
        TreeNode222.ImageIndex = 37
        TreeNode222.Name = "nod_contrat_dias"
        TreeNode222.SelectedImageIndex = 37
        TreeNode222.Text = "Gestionar contratistas"
        TreeNode223.ImageIndex = 37
        TreeNode223.Name = "nod_contra"
        TreeNode223.SelectedImageIndex = 37
        TreeNode223.Text = "Contratistas"
        TreeNode224.ImageIndex = 44
        TreeNode224.Name = "Raiz_recursos_humanos"
        TreeNode224.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode224.SelectedImageIndex = 44
        TreeNode224.Text = "Recursos humanos"
        TreeNode225.ImageIndex = 136
        TreeNode225.Name = "nodConsultVot"
        TreeNode225.SelectedImageIndex = 136
        TreeNode225.Text = "Consultar votaciónes"
        TreeNode226.ImageIndex = 83
        TreeNode226.Name = "nodGesGrup"
        TreeNode226.SelectedImageIndex = 83
        TreeNode226.Text = "Gestionar grupos votación"
        TreeNode227.ImageIndex = 140
        TreeNode227.Name = "nodIngVot"
        TreeNode227.SelectedImageIndex = 140
        TreeNode227.Text = "Ingresar votación"
        TreeNode228.ImageIndex = 83
        TreeNode228.Name = "RaizAdminVot"
        TreeNode228.SelectedImageIndex = 83
        TreeNode228.Text = "Administrar votación"
        TreeNode229.ImageIndex = 5
        TreeNode229.Name = "nod_constar_eval_prov"
        TreeNode229.SelectedImageIndex = 5
        TreeNode229.Text = "Consultar"
        TreeNode230.ImageIndex = 145
        TreeNode230.Name = "nod_evaluacion_prov"
        TreeNode230.SelectedImageIndex = 145
        TreeNode230.Text = "Evaluación"
        TreeNode231.ImageIndex = 127
        TreeNode231.Name = "nod_graficar_evaluaciones"
        TreeNode231.SelectedImageIndex = 127
        TreeNode231.Text = "Graficar evaluaciones"
        TreeNode232.ImageIndex = 99
        TreeNode232.Name = "nod_maestro_prov_cat"
        TreeNode232.SelectedImageIndex = 99
        TreeNode232.Text = "Maestro proveedor-categoria"
        TreeNode233.ImageIndex = 86
        TreeNode233.Name = "nod_gestionar_tendencias"
        TreeNode233.SelectedImageIndex = 86
        TreeNode233.Text = "Gestionar_tendencias"
        TreeNode234.ImageIndex = 145
        TreeNode234.Name = "Raiz_evaluacion_proveedores"
        TreeNode234.SelectedImageIndex = 145
        TreeNode234.Text = "Evaluación de proveedores"
        TreeNode235.ImageIndex = 69
        TreeNode235.Name = "nod_generar_sol_compra"
        TreeNode235.SelectedImageIndex = 69
        TreeNode235.Text = "Generar solicitud de servicio"
        TreeNode236.ImageIndex = 120
        TreeNode236.Name = "nod_admin_sol_compra"
        TreeNode236.SelectedImageIndex = 120
        TreeNode236.Text = "Administrar solicitudes de servicios"
        TreeNode237.ImageIndex = 136
        TreeNode237.Name = "nod_infor_cant_entre"
        TreeNode237.SelectedImageIndex = 136
        TreeNode237.Text = "Consultar material aut vs reg"
        TreeNode238.ImageIndex = 109
        TreeNode238.Name = "Raiz_sol_servicio"
        TreeNode238.SelectedImageIndex = 109
        TreeNode238.Text = "Solicitudes de servicio"
        TreeNode239.ImageIndex = 144
        TreeNode239.Name = "nod_admin_ord_compra"
        TreeNode239.SelectedImageIndex = 144
        TreeNode239.Text = "Administrar ordenes de compra"
        TreeNode240.ImageIndex = 69
        TreeNode240.Name = "nod_generar_ord_compra"
        TreeNode240.SelectedImageIndex = 69
        TreeNode240.Text = "Generar orden de compra"
        TreeNode241.ImageIndex = 144
        TreeNode241.Name = "RaizSolCompra"
        TreeNode241.SelectedImageIndex = 144
        TreeNode241.Text = "Ordenes de compra"
        TreeNode242.ImageIndex = 147
        TreeNode242.Name = "nod_salida_almacen"
        TreeNode242.SelectedImageIndex = 147
        TreeNode242.Text = "Generar salida de almacen"
        TreeNode243.ImageIndex = 136
        TreeNode243.Name = "nod_consult_salida_almacen"
        TreeNode243.SelectedImageIndex = 136
        TreeNode243.Text = "Consultar salidas de almacen"
        TreeNode244.ImageIndex = 147
        TreeNode244.Name = "RaizSalidaAlmacen"
        TreeNode244.SelectedImageIndex = 147
        TreeNode244.Text = "Salidas de almacen"
        TreeNode245.ImageIndex = 118
        TreeNode245.Name = "nod_salida_alambron"
        TreeNode245.SelectedImageIndex = 118
        TreeNode245.Text = "Salida de alambrón"
        TreeNode246.ImageIndex = 136
        TreeNode246.Name = "nod_consultar_salida_alambron"
        TreeNode246.SelectedImageIndex = 136
        TreeNode246.Text = "Consultar salida de alambrón"
        TreeNode247.ImageIndex = 118
        TreeNode247.Name = "RaizSalidaAlambron"
        TreeNode247.SelectedImageIndex = 118
        TreeNode247.Text = "Salidas de alambrón"
        TreeNode248.ImageIndex = 116
        TreeNode248.Name = "nod_tiquetes_alambron"
        TreeNode248.SelectedImageIndex = 116
        TreeNode248.Text = "Tiquetes de alambrón"
        TreeNode249.ImageIndex = 127
        TreeNode249.Name = "nod_auditoria_tiquete"
        TreeNode249.SelectedImageIndex = 127
        TreeNode249.Text = "Auditoria de ingreso de materia prima"
        TreeNode250.ImageIndex = 78
        TreeNode250.Name = "nod_planillas_cargue"
        TreeNode250.SelectedImageIndex = 78
        TreeNode250.Text = "Planillas de descargue de alambrón"
        TreeNode251.ImageIndex = 105
        TreeNode251.Name = "NodPrincipalHandHeld"
        TreeNode251.SelectedImageIndex = 105
        TreeNode251.Text = "Menú principal Hand-Held"
        TreeNode252.ImageIndex = 118
        TreeNode252.Name = "RaizAlambron"
        TreeNode252.SelectedImageIndex = 118
        TreeNode252.Text = "Gestión de alambrón"
        TreeNode253.ImageIndex = 148
        TreeNode253.Name = "nod_infor_estupe"
        TreeNode253.SelectedImageIndex = 148
        TreeNode253.Text = "Información estupefacientes"
        TreeNode254.ImageIndex = 148
        TreeNode254.Name = "RaizEstupefacientes"
        TreeNode254.SelectedImageIndex = 148
        TreeNode254.Text = "Estupefacientes"
        TreeNode255.ImageIndex = 116
        TreeNode255.Name = "nod_generar_tiquetes_terminado"
        TreeNode255.SelectedImageIndex = 116
        TreeNode255.Text = "Generar tiquetes producto temrinado"
        TreeNode256.ImageIndex = 116
        TreeNode256.Name = "Raiz_generar_tiquetes_terminado"
        TreeNode256.SelectedImageIndex = 116
        TreeNode256.Text = "Tiquetes producto terminado"
        TreeNode257.ImageIndex = 144
        TreeNode257.Name = "Raiz_compras"
        TreeNode257.SelectedImageIndex = 144
        TreeNode257.Text = "Compras"
        TreeNode258.ImageIndex = 136
        TreeNode258.Name = "nod_consultar_proc"
        TreeNode258.SelectedImageIndex = 136
        TreeNode258.Text = "Consultar procedimientos"
        TreeNode259.ImageIndex = 69
        TreeNode259.Name = "nod_gest_proc"
        TreeNode259.SelectedImageIndex = 69
        TreeNode259.Text = "Gestionar procedimientos"
        TreeNode260.ImageIndex = 99
        TreeNode260.Name = "nod_mae_cargos"
        TreeNode260.SelectedImageIndex = 99
        TreeNode260.Text = "Maestro cargos"
        TreeNode261.ImageIndex = 127
        TreeNode261.Name = "nod_auditoria"
        TreeNode261.SelectedImageIndex = 127
        TreeNode261.Text = "Auditoria"
        TreeNode262.ImageIndex = 36
        TreeNode262.Name = "nod_cambio_bod"
        TreeNode262.SelectedImageIndex = 36
        TreeNode262.Text = "Cambiar pedido bodega"
        TreeNode263.ImageIndex = 90
        TreeNode263.Name = "nod_fecha_entrega"
        TreeNode263.SelectedImageIndex = 90
        TreeNode263.Text = "Relación factura-pedido-entrega"
        TreeNode264.ImageIndex = 27
        TreeNode264.Name = "nod_formato_stiker"
        TreeNode264.SelectedImageIndex = 27
        TreeNode264.Text = "Formato impresión etiquetas"
        TreeNode265.ImageIndex = 10
        TreeNode265.Name = "nod_gestionar_no_conforme"
        TreeNode265.SelectedImageIndex = 10
        TreeNode265.Text = "Gestionar producto no conforme"
        TreeNode266.ImageIndex = 150
        TreeNode266.Name = "nod_ppal_despachos"
        TreeNode266.SelectedImageIndex = 150
        TreeNode266.Text = "Traslado de la  B 2 a la 3"
        TreeNode267.ImageIndex = 151
        TreeNode267.Name = "Nod_estado_maquinas"
        TreeNode267.SelectedImageIndex = 151
        TreeNode267.Text = "Control Esatado maquinas"
        TreeNode268.ImageIndex = 89
        TreeNode268.Name = "Raiz_logistica"
        TreeNode268.SelectedImageIndex = 89
        TreeNode268.Text = "Logistica"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode80, TreeNode197, TreeNode224, TreeNode228, TreeNode257, TreeNode261, TreeNode268})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(399, 404)
        Me.TreeView1.TabIndex = 42
        '
        'FrmGestPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 470)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnQuitarMod)
        Me.Controls.Add(Me.btnAddmodulo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listPermisosUsuario)
        Me.Controls.Add(Me.listaTipoUsu)
        Me.Name = "FrmGestPermisos"
        Me.Text = "Gestionar permisos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listaTipoUsu As System.Windows.Forms.ListBox
    Friend WithEvents listPermisosUsuario As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddmodulo As System.Windows.Forms.Button
    Friend WithEvents btnQuitarMod As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TreeView1 As TreeView
End Class
