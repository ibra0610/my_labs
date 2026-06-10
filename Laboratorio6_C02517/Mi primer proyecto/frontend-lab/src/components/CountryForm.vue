<template>
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow" style="max-width: 400px; width: 100%">
            <h3 class="text-center">Formulario de creación de países</h3>
            <div
                v-if="successMessage"
                id="success-message"
                class="success-message"
            >
                {{ successMessage }}
            </div>
            <form @submit.prevent="saveCountry">
                <div class="form-group">
                    <label for="nombre">Nombre:</label>
                    <input
                        v-model="formData.Name"
                        type="text"
                        id="name"
                        class="form-control"
                        required
                    />
                </div>
                <div class="form-group">
                    <label for="continente">Continente:</label>
                    <select
                        v-model="formData.Continent"
                        id="continente"
                        required
                        class="form-control"
                    >
                        <option value="" disabled>Seleccione un continente</option>
                        <option>África</option>
                        <option>Asia</option>
                        <option>Europa</option>
                        <option>América</option>
                        <option>Oceanía</option>
                        <option>Antártida</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="idioma">Idioma:</label>
                    <input
                        v-model="formData.Language"
                        type="text"
                        id="idioma"
                        class="form-control"
                        required
                    />
                </div>
                <div>
                    <button type="submit" class="btn btn-success btn-block">
                        Guardar
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import axios from "axios";
export default {
    data () {
        return {
            formData: { Name: "", Continent: "", Language: "" },
            successMessage: ""
        };
    },
    methods: {
        saveCountry() {
            console.log("Datos a guardar:", this.formData);
            axios
                .post("https://localhost:7053/api/Country", {
                    Name: this.formData.Name,
                    Continent: this.formData.Continent,
                    Language: this.formData.Language,
                })
                .then((response) => {
                    console.log(response);
                    this.successMessage = "País creado correctamente";
                    setTimeout(() => {
                        window.location.href = "/";
                    }, 2000);
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
    },
};
</script>

<style>
.success-message {
  color: green;
  font-weight: bold;
  margin-bottom: 15px;
}
</style>