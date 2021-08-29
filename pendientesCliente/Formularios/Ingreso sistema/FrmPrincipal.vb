Imports entidadNegocios
Imports logicaNegocios
Public Class FrmPrincipal
    Private objUsuario As UsuarioEn
    Private objOpSimplesLn As New Op_simpesLn
    Private listModulos As New List(Of Object)
    Private listNodosEliminar As New List(Of TreeNode)
    Private cerrar_desde_notificacion As Boolean = False
    Private obj_Op_simpesLn As New Op_simpesLn
    Private validar_nomina As Boolean
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim frm As New Frm_alerta_bd
    Dim val_timer As String
    Dim time_autocierre As Integer = 0
    Private Sub PrintRecursive(ByVal n As TreeNode, ByVal tipo As String)
        If (n.Nodes.Count = 0) Then
            If (tipo = "nodo") Then
                permisoModulo(n)
            ElseIf (tipo = "Raiz") Then
                If (n.Name(0) = "R") Then
                    listNodosEliminar.Add(n)
                End If
            End If
        End If
        Dim aNode As TreeNode
        For Each aNode In n.Nodes
            PrintRecursive(aNode, tipo)
        Next
    End Sub
    Private Sub eliminarNodos()
        For i = 0 To listNodosEliminar.Count - 1
            TreeView1.Nodes.Remove(listNodosEliminar(i))
        Next
        listNodosEliminar = New List(Of TreeNode)
    End Sub
    Private Sub permisoModulo(ByVal nodo As TreeNode)
        Dim sw As Boolean = False
        For i = 0 To listModulos.Count - 1
            If (listModulos(i).trim = nodo.Name) Then
                sw = True
            End If
        Next
        If (sw = False) Then
            listNodosEliminar.Add(nodo)
        End If
    End Sub
    Private Sub CallRecursive(ByVal aTreeView As TreeView, ByVal tipo As String)
        Dim n As TreeNode
        For Each n In aTreeView.Nodes
            PrintRecursive(n, tipo)
        Next
    End Sub

    Public Sub Main(ByVal permiso As String, ByVal objUsuarioEn As UsuarioEn, ByVal validar_nomina As Boolean)
        time_autocierre = 540
        Label2.Text = time_autocierre
        'autocierre.Enabled = True
        Me.validar_nomina = validar_nomina
        permiso = Trim(permiso)
        listModulos = objOpSimplesLn.lista("SELECT modulo FROM J_spic_per_mod WHERE permiso = '" & permiso & "'")
        CallRecursive(TreeView1, "nodo")
        eliminarNodos()
        CallRecursive(TreeView1, "Raiz")
        eliminarNodos()
        CallRecursive(TreeView1, "Raiz")
        eliminarNodos()
        objUsuario = objUsuarioEn
        lblNom.Text += " " & objUsuario.nombre.ToUpper
        nombres_db()
        If validar_nomina Then
            Dim nit As String = ""
            If IsNumeric(objUsuario.nit) Then
                Dim centros As String = objOpSimplesLn.consultValorTodo("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & objUsuario.nit, "PRODUCCION")
                If centros <> "" And permiso <> "ADMIN" And permiso <> "DIR_PRODUCCION" And permiso <> "NOMINA" And permiso <> "COOR_PROD" And permiso <> "LOGISTICA" Then
                    If Now.Hour > 6 Then
                        Dim frm As New Frm_liqui_reloj
                        frm.Show()
                        Me.Close()
                        frm.MAIN("nod_liqui_reloj", objUsuario, True)
                        frm.Activate()
                        frm.WindowState = FormWindowState.Normal
                    End If
                End If
            End If
        End If
        Me.validar_nomina = False
    End Sub
    Private Sub TreeView1_AfterSelect_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim vendedor As Integer = objUsuario.Vendedor
        Dim listColumnas As New List(Of String)
        Dim nodeName As String = TreeView1.SelectedNode.Name
        Dim permiso As String = objUsuario.permiso.Trim
        Select Case (nodeName)
            Case "nod_ppto_vtas"
                FrmAnalisisPres.Show()
                FrmAnalisisPres.Activate()
                FrmAnalisisPres.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_acum_vtas_vend"
                FrmAcumVtasVend.Show()
                FrmAcumVtasVend.Activate()
                FrmAcumVtasVend.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_acum_vtas"
                FrmAcumVenClien.Show()
                FrmAcumVenClien.Activate()
                FrmAcumVenClien.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_est_clien_vend"
                FrmEstClienVend.Show()
                FrmEstClienVend.Activate()
                FrmEstClienVend.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_seg_vend"
                FrmSegVendAct.Show()
                FrmSegVendAct.Activate()
                FrmSegVendAct.Main(nodeName, objUsuario)
                Me.WindowState = 1
            Case "nod_ppto_rec"
                FrmPpto_recaudo.Show()
                FrmPpto_recaudo.Activate()
                FrmPpto_recaudo.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_anali_vrKilo"
                FrmAnVrKilo.Show()
                FrmAnVrKilo.Activate()
                FrmAnVrKilo.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_info_clientes"
                frmPendientes.Show()
                frmPendientes.Activate()
                frmPendientes.Main(nodeName, permiso, objUsuario, objUsuario)
                Me.WindowState = 1

            Case "nod_vtas_clie_prod"
                FrmVtasClienProd.Show()
                FrmVtasClienProd.Activate()
                FrmVtasClienProd.Main(nodeName, permiso)
                Me.WindowState = 1

            Case "nod_an_pend"
                FrmAnalisisPedido.Show()
                FrmAnalisisPedido.Activate()
                FrmAnalisisPedido.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nodGestUsu"
                FrmRegUsuario.Show()
                FrmRegUsuario.Activate()
                Me.WindowState = 1

            Case "nod_ing_vtas"
                FrmIngVtas.Show()
                FrmIngVtas.Activate()
                FrmIngVtas.Main(nodeName, objUsuario)
                Me.WindowState = 1

            Case "nod_aud_inv"
                Frm_audit_inv.Show()
                Frm_audit_inv.Activate()
                Frm_audit_inv.Main(nodeName, permiso)
                Me.WindowState = 1

            Case "nod_pend_prod"
                Frm_pend_prod.Show()
                Frm_pend_prod.Activate()
                Frm_pend_prod.Main(nodeName, permiso)
                Me.WindowState = 1

            Case "nod_anticipos"
                Frm_anticipo.Show()
                Frm_anticipo.Main(vendedor, nodeName, permiso)
                Frm_anticipo.Activate()
                Me.WindowState = 1

            Case "nod_seg_ppto"
                Frm_dtalle_seg_ppto.Show()
                Frm_dtalle_seg_ppto.Main(vendedor, nodeName, permiso, objUsuario)
                Frm_dtalle_seg_ppto.Activate()
                Me.WindowState = 1

            Case "nod_pend_prob"
                Frm_ptes_problem.Show()
                Frm_ptes_problem.Main(vendedor, objUsuario.usuario)
                Frm_ptes_problem.Activate()
                Me.WindowState = 1
            Case "nod_cartera_ing_vtas"
                frmCarteraIngVtas.Show()
                frmCarteraIngVtas.Main(vendedor, objUsuario)
                frmCarteraIngVtas.Activate()
                Me.WindowState = 1

            Case "nod_pendientes_vend"
                Frm_info_pendientes.Show()
                Frm_info_pendientes.Main(vendedor, objUsuario.usuario)
                Frm_info_pendientes.Activate()
                Me.WindowState = 1

            Case "nod_consul_ppto_rec"
                FrmConsulPptoRec.Show()
                FrmConsulPptoRec.Activate()
                Me.WindowState = 1

            Case "nod_consult_ppto_vtas"
                FrmConsultarPptoRec.Show()
                FrmConsultarPptoRec.Activate()
                Me.WindowState = 1

            Case "nod_info_dane"
                Form_informe_dane.Show()
                Form_informe_dane.Activate()
                Form_informe_dane.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_despachos"
                frmDespacho.Show()
                frmDespacho.Main(0, vendedor)
                frmDespacho.Activate()
                Me.WindowState = 1
            Case "nod_traz_vtas_linea"
                Frm_traz_vtas_consol.Show()
                Frm_traz_vtas_consol.Activate()
                Frm_traz_vtas_consol.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_ing_trefilacion"
                Frm_ing_trefilacion.Show()
                Frm_ing_trefilacion.Activate()
                Frm_ing_trefilacion.Main(nodeName, permiso)
                Me.WindowState = 1
            Case ("nod_Vtas_lin_ciuid")
                Frm_vtas_vend_ciud.Show()
                Frm_vtas_vend_ciud.Activate()
                Frm_vtas_vend_ciud.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_ing_punt"
                Frm_Ing_puntilleria.Show()
                Frm_Ing_puntilleria.Activate()
                'Frm_Ing_puntilleria.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_ing_puas"
                Frm_Ing_puas.Show()
                Frm_Ing_puas.Activate()
                Frm_Ing_puas.Main(nodeName, objUsuario)
                Me.WindowState = 1
            Case "nod_vtas_client_idCor"
                Frm_vtas_clien_idCor.Show()
                Frm_vtas_clien_idCor.Activate()
                Frm_vtas_clien_idCor.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_ppal_clientes"
                Frm_ppal_clientes.Show()
                Frm_ppal_clientes.Activate()
                Frm_ppal_clientes.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_correrias"
                Frm_correria.Show()
                Frm_correria.Activate()
                Frm_correria.Main(nodeName, permiso, objUsuario)
                Me.WindowState = 1
            Case "nod_eficiencias"
                Frm_eficiencias.Show()
                Frm_eficiencias.Activate()
                Frm_eficiencias.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_ing_galv"
                Frm_consultar_galva.Show()
                Me.WindowState = 1
            Case "nodConsultVot"
                FrmConsulVotacion.Show()
                FrmConsulVotacion.Activate()
                FrmConsulVotacion.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodGesGrup"
                FrmGestGrupVot.Show()
                FrmGestGrupVot.Activate()
                FrmGestGrupVot.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodTref3"
                FrmConsTref3.Show()
                FrmConsTref3.Activate()
                Me.WindowState = 1
            Case "nod_tref_forma3"
                Frm_ing_emp_punt.Show()
                Frm_ing_emp_punt.Activate()
                Frm_ing_emp_punt.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodIngVot"
                FrmIngVotacion.Show()
                FrmIngVotacion.Activate()
                FrmIngVotacion.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodQuejasRec"
                FrmQuejaRec.Show()
                FrmQuejaRec.main(objUsuario, nodeName, permiso)
                FrmQuejaRec.Activate()
                Me.WindowState = 1
            Case "nodPrecProd"
                FrmVerificaPrecio.Show()
                FrmVerificaPrecio.Activate()
                FrmVerificaPrecio.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodGesRef"
                FrmGestRef.Show()
                FrmGestRef.Activate()
                Me.WindowState = 1
            Case "nodOrdenProd"
                FrmOrdenProdTef.Show()
                FrmOrdenProdTef.Activate()
                FrmOrdenProdTef.main(objUsuario.usuario, objUsuario.permiso, objUsuario.nit)
                Me.WindowState = 1
            Case "nodGestPermisos"
                FrmGestPermisos.Show()
                FrmGestPermisos.main(TreeView1)
                FrmGestPermisos.Activate()
                Me.WindowState = 1
            Case "nod_Acerca_de"
                acerca_de.Show()
                Me.WindowState = 1
            Case "nodMaestroModulo"
                listColumnas.Add("descripcion")
                listColumnas.Add("nom_modulo")
                listColumnas.Add("destinatarios_correo")
                FrmMaeGestMod.Show()
                FrmMaeGestMod.main("J_spic_modulos", "modulos", "CORSAN", listColumnas)
                FrmMaeGestMod.Activate()
                Me.WindowState = 1
            Case "nodMaestroPermiso"
                listColumnas.Add("descripcion")
                FrmMaeGestMod.Show()
                FrmMaeGestMod.main("J_spic_permiso", "permisos", "CORSAN", listColumnas)
                FrmMaeGestMod.Activate()
                Me.WindowState = 1
            Case "nod_cambio_bod"
                FrmCambioBod.Show()
                FrmCambioBod.Activate()
                FrmCambioBod.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodPulimiento"
                FrmIngProdPulimiento.Show()
                FrmIngProdPulimiento.Activate()
                FrmIngProdPulimiento.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodCorreccion"
                Frm_Solicitud_Correccion.Show()
                Frm_Solicitud_Correccion.Activate()
                Frm_Solicitud_Correccion.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodMaeRepuestos"
                listColumnas.Add("descripcion")
                listColumnas.Add("id_Repuesto")
                FrmMaeGestMod.Show()
                FrmMaeGestMod.main("b_Repuestos", "Repuestos", "PRODUCCION", listColumnas)
                FrmMaeGestMod.Activate()
                Me.WindowState = 1
            Case "nod_galv_baches"
                FRM_ing_galv_baches.Show()
                FRM_ing_galv_baches.LlenarInicial("180", "Galvanizado Planta 1")
                FRM_ing_galv_baches.Activate()
                FRM_ing_galv_baches.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_temple"
                FRM_ing_galv_baches.Show()
                FRM_ing_galv_baches.LlenarInicial("213", "Tratamientos Térmicos")
                FRM_ing_galv_baches.Main(nodeName, permiso)
                FRM_ing_galv_baches.Activate()
                Me.WindowState = 1
            Case "nod_recocido"
                Frm_ing_recocido.Show()
                Frm_ing_recocido.Activate()
                Frm_ing_recocido.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nod_tiquete_rec_manual"
                frm_tiquete_recocido_manual.Show()
                Me.WindowState = 1
            Case "nod_auditoria_tref_rec"
                frm_aud_mp_tref_rec.Show()
                frm_aud_mp_tref_rec.Activate()
                Me.WindowState = 1
            Case "nodTransDms"
                FrmConsultTransacDms.Show()
                FrmConsultTransacDms.Activate()
                FrmConsultTransacDms.Main(nodeName, permiso)
                Me.WindowState = 1
            Case "nodAuditCambios"
                FrmAuditCambios.Show()
                FrmAuditCambios.Activate()
                Me.WindowState = 1
            Case "nodMaeCoordVend"
                listColumnas.Add("usuario")
                listColumnas.Add("vendedor")
                FrmMaeGestMod.Show()
                FrmMaeGestMod.main("J_spic_coord_vend", "Vendedores asociados a un coordinador", "CORSAN", listColumnas)
                FrmMaeGestMod.Activate()
                Me.WindowState = 1
            Case "nodMaeIpCorreos"
                listColumnas.Add("descripcion")
                listColumnas.Add("ip")
                listColumnas.Add("puerto")
                FrmMaeGestMod.Show()
                FrmMaeGestMod.main("J_spic_servidores_correo", "Direcciones entrada y salida (Correos)", "CORSAN", listColumnas)
                FrmMaeGestMod.Activate()
                Me.WindowState = 1
            Case "nodTranManDmsSpic"
                FrmTransacManualDmsSpic.Show()
                FrmTransacManualDmsSpic.Activate()
                Me.WindowState = 1
            Case "nodGenFichasYcertf"
                FrmGenFichasYcertf.Show()
                FrmGenFichasYcertf.Activate()
                Me.WindowState = 1
            Case "nod_consultar_certificados"
                Frm_historico_certificados.Show()
                Frm_historico_certificados.Main(objUsuario)
                Frm_historico_certificados.Activate()
                Me.WindowState = 1
            Case "nod_info_empleados"
                Frm_info_empleados.Show()
                Frm_info_empleados.MAIN("nod_info_empleados", objUsuario)
                Frm_info_empleados.Activate()
                Me.WindowState = 1
            Case "nod_cambiar_centro"
                frm_cambiar_centro.Show()
                frm_cambiar_centro.main(objUsuario)
                frm_cambiar_centro.Activate()
                Me.WindowState = 1
            Case "nod_maestro_fichas"
                Dim frm As New frm_maestro_fichas2
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_audit_ped"
                FrmAuditPedidos.Show()
                FrmAuditPedidos.Activate()
                Me.WindowState = 1
            Case "nodOpTransaccion"
                FrmMaestroTransHandHeld.Show()
                FrmMaestroTransHandHeld.Activate()
                Me.WindowState = 1
            Case "nod_GestTransaSinStock"
                FrmGestTransaSinStock.Show()
                FrmGestTransaSinStock.MAIN(objUsuario, permiso)
                FrmGestTransaSinStock.Activate()
                Me.WindowState = 1
            Case "nod_tras_bod_hand"
                Frm_traslados_bodega.Show()
                Frm_traslados_bodega.Main(nodeName)
                Frm_traslados_bodega.Activate()
                Me.WindowState = 1
            Case "nod_MaestroTransHandHeld"
                FrmMaestroTransHandHeld.Show()
                FrmMaestroTransHandHeld.Activate()
                Me.WindowState = 1
            Case "nod_evaluacion_prov"
                Frm_evaluacion_proveedores.Show()
                Frm_evaluacion_proveedores.Activate()
                Me.WindowState = 1
            Case "nod_constar_eval_prov"
                Frm_consultar_eval.Show()
                Frm_consultar_eval.Activate()
                Me.WindowState = 1
            Case "nod_maestro_prov_cat"
                Frm_proveedor_categoria.Show()
                Frm_proveedor_categoria.Activate()
                Me.WindowState = 1
            Case "nod_graficar_evaluaciones"
                Dim frm As New Frm_graficar_evaluaciones
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_admin_sol_compra"
                Dim id_ventana As String
                id_ventana = "S"
                Dim frm As New Frm_consult_ordenes_compra
                frm.Show()
                frm.Main(objUsuario, id_ventana)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_admin_ord_compra"
                Dim id_ventana As String
                id_ventana = "O"
                Dim frm As New Frm_consult_ordenes_compra
                frm.Show()
                frm.Main(objUsuario, id_ventana)
                frm.Activate()
                Me.WindowState = 1
                'menu de estupefacientes agregado por david
            Case "nod_infor_estupe"
                Dim frm As New frm_estupefacientes
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_generar_sol_compra"
                Dim id_ventana As String
                id_ventana = "S"
                Dim frm As New Frm_orden_compra
                frm.Main(objUsuario, 0, "nod_generar_sol_compra", id_ventana)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_generar_ord_compra"
                Dim id_ventana As String
                id_ventana = "O"
                Dim frm As New Frm_orden_compra
                frm.Main(objUsuario, 0, "nod_generar_ord_compra", id_ventana)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_salida_materia_prima_G"
                Dim frm As New Frm_salida_materia_prima_G
                frm.Show()
                frm.Main(objUsuario, 0, "nod_salida_materia_prima_G")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consulta_materia_prima_G"
                Dim frm As New Frm_consultar_salida_materia_prima
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Orden_produccion_Galvanizado"
                Dim frm As New FrmOrdenProdGalv
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Informe_produccion_Galvanizado"
                Dim frm As New Frm_informe_galvanizado
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Informe_estado_rollos"
                Dim frm As New Frm_Estado_de_rollo
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Informe_bobinas_paradas"
                Dim frm As New Frm_bobinas_paradas
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Informe_tiempo_trabajo"
                Dim frm As New Frm_tiempo_trabajo_Galv
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Informe_resumen_galvanizado"
                Dim frm As New Frm_resumenes
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_per_activo"
                Dim frm As New Frm_personal_activo_corsan
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_orden_prod_puas"
                Dim frm As New frm_control_orden_puas
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_crear_orden_puas"
                Dim frm As New frm_orden_prod_puas
                frm.main(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_infor_paros_puas"
                Dim frm As New Frm_informe_paros_puas
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_gestionar_tendencias"
                Dim frm As New Frm_gestionar_tendencias
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_mae_cargos"
                listColumnas.Add("descripcion")
                FrmMaeGestMod.Show()
                FrmMaeGestMod.main("C_cargos_corsan", "Maestro cargos corsan", "PRODUCCION", listColumnas)
                FrmMaeGestMod.Activate()
                Me.WindowState = 1
            Case "nod_consultar_proc"
                Dim frm As New Frm_consultar_proc
                frm.Show()
                frm.Main(objUsuario, "nod_gest_proc")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_gest_proc"
                Dim frm As New Frm_gestionar_procedimientos
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
                frm.Main(objUsuario, 0, "nod_gest_proc")
            Case "nod_IngTornilleria"
                Dim frm As New FrmIngTornilleria
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_vtas_zona"
                Dim frm As New Frm_vtas_zona
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_AnalisisVentas"
                Dim frm As New FrmAnalisisVentas
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_pend_zona"
                Dim frm As New Frm_pend_zona
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_reglas_comisiones"
                Dim frm As New Frm_reglas_comisiones
                frm.Show()
                frm.main(objUsuario.usuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_liquidacion_com"
                Dim frm As New Frm_liquidacion
                frm.Show()
                frm.Main("nod_liquidacion_com", objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_seg_pendientes"
                Dim frm As New Frm_seg_pendientes
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_vtas_cliente_linea_mes"
                Dim frm As New Frm_vtas_cliente_linea_mes
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_fecha_entrega"
                Dim frm As New Frm_fecha_entrega
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_informe_ausentismos"
                Dim frm As New Frm_liquidar_reloj
                frm.Show()
                frm.MAIN("nod_informe_ausentismos", objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_trazabilidad_transacciones"
                Dim frm As New Frm_trazabilidad_transacciones
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Trazabilidad_clientes_atendidos"
                Dim frm As New Frm_Trazabilidad_clientes_atendidos
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_evaluacione_desempeno"
                Dim frm As New Frm_Evaluacion_corsan
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consultar_eval_desempeno"
                Dim frm As New Frm_consultar_eval_desempeno
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_permisos_evaluaciones"
                Dim frm As New Frm_permisos_evaluaciones
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_permisos_evaluaciones"
                Dim frm As New Frm_permisos_evaluaciones
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_cerrar_for"
                Dim frm As New Frm_cierre_forzado
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_super_modulo_consult_vtas"
                Dim frm As New Frm_super_modulo_consult_vtas
                frm.Main(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_dias_vacaciones"
                Dim frm As New Frm_dias_vacaciones
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_encu_clientes"
                Dim frm As New Frm_encuesta_clientes
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consult_encuesta_cliente"
                Dim frm As New Frm_consultar_encuesta_cli
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_seguimiento_ppto_mes"
                Dim frm As New Frm_seguimiento_ppto_mes
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_formato_stiker"
                Dim frm As New Frm_formato_stiker
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_maximos_minimos"
                Dim frm As New Frm_maximos_minimos
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_gest_desperdicios"
                Dim frm As New Frm_desperdicios
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nodIngVtasMovil"
                FrmIngVtasMovil.Show()
                FrmIngVtasMovil.Activate()
                FrmIngVtasMovil.Main(nodeName, objUsuario)
                Me.WindowState = 1
            Case "nod_super_modulo_consult_pendientes"
                Dim frm As New Frm_super_modulo_consult_pendientes
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_ppto_produccion"
                Dim frm As New Frm_ppto_produccion
                frm.Show()
                frm.MAIN(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_cod_vel"
                Dim frm As New frm_codigo_vel_tref
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_seg_ppto_produccion"
                Dim frm As New Frm_seg_ppto_produccion
                frm.Show()
                frm.MAIN(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_seg_grupos"
                Dim frm As New FrmSeguimientoGrupos
                frm.Show()
                frm.main("nod_seg_grupos", objUsuario.permiso, objUsuario.Vendedor)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_entradas_salidas_ref"
                Dim frm As New Frm_entradas_salidas_ref
                frm.Show()
                frm.MAIN(objUsuario.permiso)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_tiempos_laborados"
                Dim frm As New Frm_reloj
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_salida_almacen"
                Dim frm As New Frm_salida_almacen
                frm.Show()
                frm.Main(objUsuario, 0, "nod_salida_almacen")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consult_salida_almacen"
                Dim frm As New Frm_consult_salida_almacen
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_entradas_salidas_diarias"
                Dim frm As New Frm_entradas_salidas_diarias
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_empaque_puntilleria"
                Dim frm As New Frm_empaque_puntilleria
                frm.Show()
                frm.Main("nod_empaque_puntilleria", objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_rotacion_personal"
                Dim frm As New Frm_rotacion_personal
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_informe_temporales"
                Dim frm As New Frm_informe_temporales
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_contrat_dias"
                Dim frm As New frm_registro_proveedores
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_liqui_reloj"
                Dim frm As New Frm_liqui_reloj
                frm.Show()
                frm.MAIN("nod_liqui_reloj", objUsuario, False)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_galv_f2"
                Dim frm As New Frm_ing_galv
                frm.Show()
                frm.Main("nod_galv_f2", objUsuario.permiso)
                Me.WindowState = 1
            Case "nod_programacion_turnos"
                Dim frm As New Frm_programacion_turnos
                frm.Show()
                frm.MAIN("nod_galv_f2", objUsuario)
                Me.WindowState = 1
            Case "nod_MaePeriodos"
                Dim frm As New FrmInvMetrologia
                frm.Show()
                Me.WindowState = 1
            Case "nod_inv_metrologia"
                Dim frm As New Frm_inv_metrologia
                frm.Show()
                Me.WindowState = 1
            Case "nod_super_modulo_consult_terceros"
                Dim frm As New Frm_super_modulo_consult_terceros
                frm.Main(objUsuario)
                frm.Show()
                Me.WindowState = 1
            Case "nod_informe_marcaciones"
                Dim frm As New Frm_informe_marcaciones
                frm.MAIN("nod_informe_marcaciones", objUsuario)
                frm.Show()
                Me.WindowState = 1
            Case "nod_salida_alambron"
                Dim frm As New Frm_salida_alambron
                frm.Main(objUsuario, 0, "nod_salida_alambron")
                frm.Show()
                Me.WindowState = 1
            Case "nod_fecha_venc_cartera"
                Dim frm As New frm_cartera_por_vencer
                frm.Show()
                Me.WindowState = 1
            Case "nod_mat_consumida"
                Dim frm As New frm_consumos_alambron
                frm.Show()
                Me.WindowState = 1
            Case "nod_mat_punt"
                Dim frm As New Frm_consumos_puntilleria
                frm.Show()
                Me.WindowState = 1
            Case "nod_mat_galv"
                Dim frm As New Frm_consumo_galva
                frm.Show()
                Me.WindowState = 1
            Case "nod_consultar_salida_alambron"
                Dim frm As New Frm_consult_salida_alambron
                frm.Main(objUsuario)
                frm.Show()
                Me.WindowState = 1
            Case "nod_tiquetes_alambron"
                Dim frm As New Frm_tiquetes_alambron
                frm.Show()
                Me.WindowState = 1
            Case "nod_gen_tiquet_tref"
                Dim frm As New frm_generar_tiquete
                frm.main(0, 0, objUsuario.nombre, objUsuario.nit)
                frm.Show()
                Me.WindowState = 1
            Case "nod_infor_cant_entre"
                Dim frm As New Frm_infor_cant_entre
                frm.Show()
                Me.WindowState = 1
            Case "nod_auditoria_tiquete"
                Dim frm As New Frm_auditoria_tiquetes
                frm.Show()
                frm.Main(0, objUsuario)
                Me.WindowState = 1
            Case "nod_planillas_cargue"
                Dim frm As New Frm_planillas_cargue
                frm.Show()
                frm.MAIN(0, objUsuario)
                Me.WindowState = 1
            Case "NodPrincipalHandHeld"
                Dim frm As New Frm_ppal_alambron
                frm.Show()
                Me.WindowState = 1
            Case "nod_super_modulo_consult_cartera"
                Dim frm As New Frm_super_modulo_consult_cartera
                frm.Main(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_super_modulo_consult_recaudos"
                Dim frm As New Frm_super_modulo_consult_recaudos
                frm.Main(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "Nod_consult_compromisos"
                Dim frm As New Frm_consult_compromisos
                frm.MAIN(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_informe_nov_pendientes"
                Dim frm As New Frm_informe_nov_pendientes
                frm.MAIN(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_ppto_gastos"
                Dim frm As New Frm_ppto_gastos()
                frm.MAIN(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_seg_ppto_gastos"
                Dim frm As New Frm_seg_ppto_gastos()
                frm.MAIN(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_generar_tiquetes_terminado"
                Dim frm As New Frm_generar_tiquetes_terminado
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_cerrar_por_ruta"
                groupRutaCerrar.Visible = True
            Case "nod_paros_galv"
                Dim frm As New Frm_informe_paros_galv
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_gestionar_no_conforme"
            Case "nod_super_modulo_consult_gastos_vendedor"
                Dim frm As New Frm_super_modulo_consult_gastos_vendedor()
                frm.Main(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_ppto_articulos"
                Dim frm As New Frm_ppto_articulos
                frm.MAIN(objUsuario)
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nodReg_personal_maquila"
                Dim frm As New FrmReg_personal_maquila
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_generar_tiquetes_terminado"
                Dim frm As New Frm_generar_tiquetes_terminado
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consultar_separe"
                Dim frm As New Frm_consultar_separe
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consult_inv_fisicos"
                Dim frm As New Frm_consultar_inventario_fisico
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_mp_puntilleria"
                Dim frm As New Frm_solicitud_mp_puntilleria
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consult_solicitud_mp_punt"
                Dim frm As New Frm_consult_solicitud_mp_punt
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_orden_prod_punt"
                Dim frm As New Frm_orden_prod_punt
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_cambio_cliente_vendedor"
                Dim frm As New Frm_cambio_cliente_vendedor
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_auditoria_puntilleria"
                Dim frm As New Frm_auditoria_puntilleria
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_mp_recocido"
                Dim frm As New Form_solicitud_mp_recocido
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consult_solicitud_mp_recocido"
                Dim frm As New Frm_consultar_solicitud_mp_recocido
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_orden_produccion_rec"
                Dim frm As New frm_ordne_prdo_rec2
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_auditoria_recocido"
                Dim frm As New frm_auditoria_recocido
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_proyectos"
                Dim frm As New Frm_proyectos
                frm.Show()
                frm.MAIN(objUsuario, 0, Now, Now)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consultar_proyecto"
                Dim frm As New Frm_consultar_proyectos
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_recocido_calidad"
                Dim frm As New frm_recocido_calidad
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_auditoria_inventario"
                Dim frm As New frm_control_inv_aud
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_auditoria_alambres"
                Dim frm As New frm_seguimiento_alambre
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_mp_puas"
                Dim frm As New frm_solicitud_mp_puas
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consult_solicitud_mp_puas"
                Dim frm As New Frm_consultar_solicitud_mp_puas
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_scal"
                Dim frm As New frm_solicitud_trefscal
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consulta_scal"
                Dim frm As New Frm_consultar_solicitud_mp_scal
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_scae"
                Dim frm As New frm_solicitud_trefscae
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consulta_scae"
                Dim frm As New Frm_consultar_solicitud_mp_scae
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_sar"
                Dim frm As New frm_solicitud_trefsar
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consulta_sar"
                Dim frm As New Frm_consultar_solicitud_mp_sar
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_solicitud_sav"
                Dim frm As New frm_solicitud_trefsav
                frm.Show()
                frm.Main(objUsuario, 0)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_consulta_sav"
                Dim frm As New Frm_consultar_solicitud_mp_sav
                frm.Show()
                frm.Main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_informe_pers_activo"
                Dim frm As New frm_vista_personal_activo
                frm.Show()
                frm.Activate()
                Me.WindowState = 1

            Case "nod_gest_doc"
                Dim frm As New frm_documentacion_pendiente
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_manual"
                Dim frm As New frm_manuales_spic
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_tiquete_nc"
                Dim frm As New frm_no_conforme_rec
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_tiquete_nc"
                Dim frm As New frm_no_conforme_rec
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_prod_puas"
                Dim frm As New Frm_informe_prod_puas
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_limite_consumos"
                Dim frm As New Frm_limite_consumo_alambron
                frm.Show()
                frm.main(objUsuario.nombre)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_ppal_despachos"
                Dim frm As New frm_ppal_despachos
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_buzon_sugerencias_det"
                Dim frm As New frm_consulta_buzon
                frm.Show()
                frm.main(objUsuario)
                frm.Activate()
                Me.WindowState = 1
            Case "nod_buzon_cons_premios"
                Dim frm As New frm_buzon_info_premios
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_Ajus_Conts"
                Dim frm As New cboMes
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_sal_alam"
                Dim frm As New frm_Saldo_Alambron
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_act_alam"
                Dim frm As New frm_Saldo_Cambiar
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_tref_form3"
                Dim frm As New FrmConsTreForma3
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nodo_probar"
                '
                Dim frm As New FrmLogin
                frm.Show()
                frm.Activate()
                Me.WindowState = 1
            Case "nod_reporte_inspeccion_calidad"
                '
                Dim frm As New FrmReporteInspeccionCalidad
                frm.Show()
                frm.Activate()
                Me.WindowState = 1

            Case "Nod_estado_maquinas"
                Dim frm As New DassboardMaquinas
                frm.Show()
                frm.Activate()
                Me.WindowState = 1


        End Select
        TreeView1.SelectedNode = TreeView1.Nodes("raiz_ofic")
    End Sub
    'Public Sub Inactividad(ByVal TimeOut_InSec As Long)
    '    Application.Exit()
    'End Sub
    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        Me.Close()
    End Sub


    Private Sub FrmPrincipal_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If validar_nomina = False Then
            If Not cerrar_desde_notificacion Then
                Dim resp As Integer = MessageBox.Show("Esta seguro que desea salir de la aplicación? ", "Salir?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (resp = 6) Then
                    cerrar_desde_notificacion = True
                    Application.Exit()
                Else
                    e.Cancel = True
                End If
            Else
                Application.Exit()
            End If
        End If
    End Sub
    Private Sub timNotificarCerrarAplicacion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timNotificarCerrarAplicacion.Tick
        If My.Computer.Network.IsAvailable Then
            Dim ruta_actual As String = Environment.CurrentDirectory
            Dim sql As String = "SELECT estado FROM J_spic_cerrar_aplicacion_ruta WHERE ruta ='" & ruta_actual & "'"
            Dim resp As String = objOpSimplesLn.consultarVal(sql)
            Dim ruta_cerrar As String = ""
            If resp = "S" Then
                timCerrarApp.Enabled = True
                MessageBox.Show("La aplicación se cerrara en forma automatica en 1 minuto por motivo de actualización, podrá abrir la aplicación en el trascurso de los proximos 10 minutos,de antemano le ofrecemos disculpas por las molestias ocacionadas,estamos trabajando en la mejora de los procesos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub timCerrarApp_Tick(sender As Object, e As EventArgs) Handles timCerrarApp.Tick
        cerrar_desde_notificacion = True
        Application.Exit()
    End Sub


    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        gestionar_notificacion(txt_ruta.Text, True)
    End Sub
    Private Sub btn_cancelar_noti_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_noti.Click
        gestionar_notificacion(txt_ruta.Text, False)
    End Sub
    Private Sub btnCerrarGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrarGroup.Click
        groupRutaCerrar.Visible = False
    End Sub
    Private Sub gestionar_notificacion(ByVal ruta As String, ByVal crear As Boolean)
        If ruta <> "" Then
            Dim sql As String = ""
            Dim tipo As String = ""
            If crear Then
                tipo = "Creo"
                sql = "INSERT INTO J_spic_cerrar_aplicacion_ruta (ruta,estado) VALUES('" & ruta & "','S')"
            Else
                tipo = "Cancelo"
                sql = "DELETE FROM J_spic_cerrar_aplicacion_ruta"
            End If
            If obj_Op_simpesLn.ejecutar(sql, "CORSAN") > 0 Then
                If crear Then
                    Dim tiempo As Integer = timNotificarCerrarAplicacion.Interval
                    tiempo = tiempo / 60000
                    MessageBox.Show("La notificación se " & tipo & " en forma exitosa,la aplicación de cerrara en aproximadamente " & tiempo & " minutos", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("La notificación se " & tipo & " en forma exitosa", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Error al realizar la operación ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Ingrese ruta para notificar", "Ingrese ruta!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
 
    End Sub
    Private Sub nombres_db()
        Dim db_corsan As String = objOpSimplesLn.get_nom_db("CORSAN")
        Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION")
        Dim db_control As String = objOpSimplesLn.get_nom_db("CONTROL")
        lbl_db_corsan.Text = db_corsan.ToUpper
        lbl_db_produccion.Text = db_produccion.ToUpper
        lbl_db_control.Text = db_control.ToUpper
    End Sub

    Private Sub autocierre_Tick(sender As Object, e As EventArgs) Handles autocierre.Tick
        time_autocierre = time_autocierre - 1
        Label2.Text = time_autocierre
        If time_autocierre = 0 Then
            frmPrincipal_autocierre.main()
            frmPrincipal_autocierre.ShowDialog()
        End If
    End Sub

    Public Sub reiniciar_timer(ByVal numero As Integer)
        time_autocierre = numero
    End Sub
    Public Sub fin()
        End
    End Sub
    Private Sub btn_buzon_Click(sender As Object, e As EventArgs) Handles btn_buzon.Click
        frm_buzon.ShowDialog()
    End Sub
    Private Sub cierre_forzado_Tick(sender As Object, e As EventArgs) Handles cierre_forzado.Tick
        Dim sql As String
        sql = "select * from J_spic_cerrar_aplicacion"
        If obj_Ing_prodLn.consultar_valor(sql, "CORSAN") <> "0" Then
            Application.ExitThread()
        End If
    End Sub
    Private Sub tsAcercaDe_Click(sender As Object, e As EventArgs) Handles tsAcercaDe.Click
        acerca_de.Show()
        Me.WindowState = 1
    End Sub
    Private Sub tim_cumpleaños_Tick(sender As Object, e As EventArgs)
        FrmCorreosCumpleanos.Show()
    End Sub

    Private Sub timer_ping_bd_Tick(sender As Object, e As EventArgs) Handles timer_ping_bd.Tick
        If My.Computer.Network.IsAvailable() Then
            If val_timer = "1" Then
                cierre_forzado.Enabled = True
                timNotificarCerrarAplicacion.Enabled = True
                timCerrarApp.Enabled = True
                autocierre.Enabled = True
                val_timer = ""
                frm.Close()
            End If
            If My.Computer.Network.Ping("10.10.10.246", 5000) Then
                If val_timer = "1" Then
                    cierre_forzado.Enabled = True
                    timNotificarCerrarAplicacion.Enabled = True
                    timCerrarApp.Enabled = True
                    autocierre.Enabled = True
                    val_timer = ""
                    frm.Close()
                End If
            Else
                If val_timer <> "1" Then
                    If validar_formu() Then
                        val_timer = "1"
                        cierre_forzado.Enabled = False
                        timNotificarCerrarAplicacion.Enabled = False
                        timCerrarApp.Enabled = False
                        autocierre.Enabled = False
                        frm.ShowDialog()
                    End If
                End If
            End If
        Else
            If val_timer <> "1" Then
                If validar_formu() Then
                    val_timer = "1"
                    cierre_forzado.Enabled = False
                    timNotificarCerrarAplicacion.Enabled = False
                    timCerrarApp.Enabled = False
                    autocierre.Enabled = False
                    frm.ShowDialog()
                End If
            End If
        End If
    End Sub
    Private Function validar_formu()
        Dim resp As Boolean = True
        For Each f As Form In Application.OpenForms
            If f.Name = frm.Name Then
                resp = False
            End If
        Next
        Return resp
    End Function

    Private Sub Toolbar1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles Toolbar1.ItemClicked

    End Sub
End Class