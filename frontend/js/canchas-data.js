// Datos visuales de las canchas (imágenes SVG + coordenadas para el mapa)
// Cuando el backend devuelva una cancha, se busca por nombre para obtener estos datos
const CANCHAS_VISUAL = {
  "Cancha Norte": {
    lat: 4.6782,
    lng: -74.0582,
    color: "#1a5c2a",
    descripcion: "Cancha de césped sintético con iluminación nocturna y vestuarios.",
    amenidades: ["🚿 Vestuarios", "💡 Iluminación", "🅿️ Parqueadero", "🥤 Cafetería"]
  },
  "Cancha Sur": {
    lat: 4.6201,
    lng: -74.0882,
    color: "#1a3d5c",
    descripcion: "Cancha techada con piso de caucho de alta resistencia.",
    amenidades: ["🚿 Vestuarios", "🏠 Techada", "🅿️ Parqueadero"]
  },
  "Cancha Central": {
    lat: 4.6534,
    lng: -74.0836,
    color: "#3d1a5c",
    descripcion: "Cancha profesional con graderías y marcación oficial.",
    amenidades: ["🚿 Vestuarios", "💡 Iluminación", "🏟️ Graderías", "🅿️ Parqueadero", "🥤 Cafetería"]
  },
  "Cancha Estadio": {
    lat: 4.6450,
    lng: -74.0750,
    color: "#5c3d1a",
    descripcion: "Cancha de grama natural en complejo deportivo.",
    amenidades: ["🚿 Vestuarios", "💡 Iluminación", "🏟️ Graderías", "🥤 Cafetería", "🏥 Enfermería"]
  }
};

// Genera una imagen SVG de una cancha de fútbol con el color dado
function generarImagenCancha(nombre, color = "#1a5c2a") {
  const c = color;
  return `
  <svg viewBox="0 0 400 220" xmlns="http://www.w3.org/2000/svg" width="100%" height="100%">
    <!-- Fondo -->
    <rect width="400" height="220" fill="${c}"/>
    <!-- Franjas de césped -->
    <rect x="0" y="0" width="50" height="220" fill="${c}" opacity="0.7"/>
    <rect x="50" y="0" width="50" height="220" fill="${c}" opacity="0.85"/>
    <rect x="100" y="0" width="50" height="220" fill="${c}" opacity="0.7"/>
    <rect x="150" y="0" width="50" height="220" fill="${c}" opacity="0.85"/>
    <rect x="200" y="0" width="50" height="220" fill="${c}" opacity="0.7"/>
    <rect x="250" y="0" width="50" height="220" fill="${c}" opacity="0.85"/>
    <rect x="300" y="0" width="50" height="220" fill="${c}" opacity="0.7"/>
    <rect x="350" y="0" width="50" height="220" fill="${c}" opacity="0.85"/>
    <!-- Borde exterior -->
    <rect x="20" y="15" width="360" height="190" fill="none" stroke="white" stroke-width="2.5" opacity="0.9"/>
    <!-- Línea del medio -->
    <line x1="200" y1="15" x2="200" y2="205" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Círculo central -->
    <circle cx="200" cy="110" r="35" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <circle cx="200" cy="110" r="3" fill="white" opacity="0.9"/>
    <!-- Área izquierda grande -->
    <rect x="20" y="55" width="65" height="110" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Área izquierda pequeña -->
    <rect x="20" y="80" width="30" height="60" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Portería izquierda -->
    <rect x="12" y="93" width="8" height="34" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Área derecha grande -->
    <rect x="315" y="55" width="65" height="110" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Área derecha pequeña -->
    <rect x="350" y="80" width="30" height="60" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Portería derecha -->
    <rect x="380" y="93" width="8" height="34" fill="none" stroke="white" stroke-width="2" opacity="0.9"/>
    <!-- Semicírculo área izquierda -->
    <path d="M 85 95 Q 105 110 85 125" fill="none" stroke="white" stroke-width="2" opacity="0.7"/>
    <!-- Semicírculo área derecha -->
    <path d="M 315 95 Q 295 110 315 125" fill="none" stroke="white" stroke-width="2" opacity="0.7"/>
    <!-- Punto penal izquierdo -->
    <circle cx="65" cy="110" r="2.5" fill="white" opacity="0.9"/>
    <!-- Punto penal derecho -->
    <circle cx="335" cy="110" r="2.5" fill="white" opacity="0.9"/>
    <!-- Nombre de la cancha -->
    <text x="200" y="215" text-anchor="middle" fill="white" font-size="11" font-family="Arial" opacity="0.7">${nombre}</text>
  </svg>`;
}
