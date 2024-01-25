import React, { useState } from 'react';
import {Form, Button, Container, Row, Col, Card} from 'react-bootstrap';
import { useMutation, useQueryClient } from 'react-query';
import axiosInstance from "../Services/axiosInstance.js";
import {apiPath} from "../util/api.jsx";

function NewOnderzoekForm() {
    const [Titel, setTitel] = useState('');
    const [Beschrijving, setBeschrijving] = useState('');
    const [IsGekeurd, setIsGekeurd] = useState(false);


    const queryClient = useQueryClient();

    const mutation = useMutation(newonderzoek => axiosInstance.post(`${apiPath}/api/BedrijfPortaal/CreateOnderzoek`, newonderzoek), {
        onSuccess: () => {
            setTitel('');
            setBeschrijving('');
            setIsGekeurd(false)


            queryClient.invalidateQueries('tableData');
        },

    });

    const handleSubmit = (event) => {
        event.preventDefault();

        mutation.mutate({
            "Titel": Titel,
            "Beschrijving": Beschrijving

        });
    };

    return (
        <Container>
            <Card className={"Shadow"}>
                <Card.Body>
                    <Form onSubmit={handleSubmit}>
                        <Row>
                            <Col>
                                <Form.Group>
                                    <Form.Label>Titel onderzoek</Form.Label>
                                    <Form.Control
                                        type={"text"}
                                        placeholder={"Titel onderzoek" }
                                        value={Titel}
                                        onChange={e => setTitel(e.target.value)}
                                    />
                                </Form.Group>
                            </Col>
                            <Col>
                                <Form.Group>
                                    <Form.Label>Beschrijving</Form.Label>
                                    <Form.Control
                                        type={"text"}
                                        placeholder={"Beschrijving" }
                                        value={Beschrijving}
                                        onChange={e => setBeschrijving(e.target.value)}
                                    />
                                </Form.Group>
                            </Col>
                            <Col className={"d-flex align-items-end justify-content-center"}>
                                <Button variant="primary" type="submit" onClick={handleSubmit}>
                                    Submit
                                </Button>
                            </Col>
                        </Row>
                    </Form>
                </Card.Body>
            </Card>
        </Container>
);
}

export default NewOnderzoekForm;