# 🤖 GitHub Agentic Workflows para ProyectoClima

Este directorio contiene workflows agentic para automatizar tareas de calidad y testing usando GitHub Copilot.

## 📋 Workflows Disponibles

### 1. 🧪 Test Coverage Improver
- **Archivo**: `test-coverage-improver.md`
- **Trigger**: Semanal (Lunes 9 AM) o manual
- **Descripción**: Analiza la cobertura de tests y crea PRs con nuevos tests para áreas poco cubiertas
- **Output**: Pull Request con tests adicionales

### 2. ✅ PR Quality Checker
- **Archivo**: `pr-quality-checker.md`
- **Trigger**: Automático en cada Pull Request
- **Descripción**: Revisa PRs automáticamente y comenta sobre calidad, seguridad, tests y buenas prácticas
- **Output**: Comentarios en el PR con feedback estructurado

### 3. 🔎 Daily Adhoc QA
- **Archivo**: `daily-qa.md`
- **Trigger**: Diario (10 AM) o manual
- **Descripción**: Realiza testing exploratorio y busca problemas potenciales en el código
- **Output**: Issue con reporte de hallazgos

## 🚀 Instalación y Configuración

### Prerrequisitos

1. **GitHub CLI instalado**:
   ```bash
   # En Ubuntu/Debian
   sudo apt install gh

   # En macOS
   brew install gh

   # Verificar instalación
   gh --version
   ```

2. **Autenticación con GitHub**:
   ```bash
   gh auth login
   ```

3. **Extensión de GitHub Agentic Workflows**:
   ```bash
   gh extension install githubnext/gh-aw
   ```

### Activar los Workflows

1. **Compilar los workflows markdown a YAML**:

   Desde el directorio raíz del proyecto:

   ```bash
   # Compilar todos los workflows
   gh aw compile .github/workflows-md/test-coverage-improver.md
   gh aw compile .github/workflows-md/pr-quality-checker.md
   gh aw compile .github/workflows-md/daily-qa.md
   ```

   Esto generará archivos `.yml` en `.github/workflows/` que GitHub Actions ejecutará.

2. **Revisar los workflows generados**:

   ```bash
   ls -la .github/workflows/
   ```

   Deberías ver los nuevos archivos YAML generados.

3. **Commit y push**:

   ```bash
   git add .github/workflows/
   git commit -m "Add agentic quality workflows"
   git push
   ```

### Configuración de Permisos

Asegúrate de que tu repositorio tenga los permisos correctos:

1. Ve a **Settings → Actions → General**
2. En "Workflow permissions", selecciona:
   - ✅ **Read and write permissions**
   - ✅ **Allow GitHub Actions to create and approve pull requests**

## 🎮 Uso

### Ejecutar Manualmente

Puedes ejecutar cualquier workflow manualmente desde GitHub:

1. Ve a **Actions** en tu repositorio
2. Selecciona el workflow que quieres ejecutar
3. Haz click en **Run workflow**
4. Selecciona la rama y ejecuta

O desde la terminal:

```bash
# Ejecutar Test Coverage Improver
gh workflow run "Test Coverage Improver"

# Ejecutar Daily QA
gh workflow run "Daily Adhoc QA"
```

### Workflows Automáticos

- **PR Quality Checker**: Se ejecuta automáticamente cuando abres o actualizas un PR
- **Test Coverage Improver**: Se ejecuta cada lunes a las 9 AM UTC
- **Daily QA**: Se ejecuta diariamente a las 10 AM UTC

### Ver Resultados

```bash
# Ver runs recientes
gh run list

# Ver detalles de un run específico
gh run view [run-id]

# Ver logs
gh run view [run-id] --log
```

## 🔧 Personalización

Puedes personalizar los workflows editando los archivos `.md`:

1. **Cambiar horarios**: Modifica el campo `cron` en el frontmatter
2. **Modificar permisos**: Ajusta el campo `permissions`
3. **Añadir herramientas**: Agrega más tools en el campo `tools`
4. **Cambiar instrucciones**: Edita el contenido markdown del workflow

Después de modificar, vuelve a compilar:

```bash
gh aw compile .github/workflows-md/[archivo-modificado].md
```

## 📊 Monitoreo

### Ver Issues Creados por QA

```bash
gh issue list --label "qa-report"
```

### Ver PRs de Test Coverage

```bash
gh pr list --author "github-actions[bot]" --search "test coverage"
```

### Estadísticas de Workflows

```bash
# Últimas 10 ejecuciones
gh run list --limit 10

# Filtrar por workflow
gh run list --workflow="Test Coverage Improver"
```

## ⚠️ Notas Importantes

1. **Experimental**: GitHub Agentic Workflows es un proyecto de investigación de GitHub Next y no está destinado para uso en producción crítica.

2. **Revisión Humana**: Siempre revisa las sugerencias y cambios generados por los workflows antes de mergear.

3. **Recursos**: Los workflows usan minutos de GitHub Actions. Monitorea tu uso en **Settings → Billing**.

4. **Seguridad**: Los workflows tienen permisos limitados y se ejecutan en contenedores aislados.

5. **Rate Limits**: GitHub Copilot tiene límites de uso. Si alcanzas el límite, los workflows fallarán temporalmente.

## 🔍 Troubleshooting

### El workflow no se ejecuta

1. Verifica que el archivo YAML esté en `.github/workflows/`
2. Revisa la sintaxis del YAML
3. Verifica los permisos del repositorio
4. Revisa los logs: `gh run view --log`

### El workflow falla

```bash
# Ver logs detallados
gh run view [run-id] --log-failed

# Re-ejecutar un workflow fallido
gh run rerun [run-id]
```

### Problemas de permisos

Verifica que el GITHUB_TOKEN tenga los permisos necesarios en Settings → Actions → General.

## 📚 Recursos Adicionales

- [Documentación de GitHub Agentic Workflows](https://githubnext.github.io/gh-aw/)
- [Repositorio gh-aw](https://github.com/githubnext/gh-aw)
- [Ejemplos de Workflows](https://github.com/githubnext/agentics)
- [GitHub Actions Documentation](https://docs.github.com/en/actions)

## 🤝 Contribuir

Si quieres agregar más workflows o mejorar los existentes:

1. Crea un nuevo archivo `.md` en este directorio
2. Sigue la estructura de los workflows existentes
3. Compílalo con `gh aw compile`
4. Pruébalo con `gh workflow run`
5. Crea un PR con tus cambios

---

**Nota**: Estos workflows usan GitHub Copilot por defecto. Asegúrate de tener acceso a GitHub Copilot en tu organización/cuenta.
