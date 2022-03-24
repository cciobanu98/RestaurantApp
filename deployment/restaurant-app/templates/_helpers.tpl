{{/*
Define Parent Chart Global Variables (mainly API endpoints)
*/}}
{{/*
menu-service API endpoint URL.
*/}}
{{- define "global.menu-service.url" -}}
{{- printf "http://%s-menu-service/api" .Release.Name -}}
{{- end -}}
{{/*
order-service API endpoint URL.
*/}}
{{- define "global.order-service.url" -}}
{{- printf "http://%s-order-service/api" .Release.Name -}}
{{- end -}}
{{/*
users-service Management API endpoint URL.
*/}}
{{- define "global.users-service.url" -}}
{{- printf "http://%s-users-servuce/api" .Release.Name -}}
{{- end -}}
