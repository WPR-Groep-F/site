import React, { useState } from "react";
import { Form, Button, Container, Row, Col, Card } from "react-bootstrap";
import { useMutation, useQueryClient } from "react-query";
import axiosInstance from "../Services/axiosInstance.js";
import { apiPath } from "../util/api.jsx";

function NewOnderzoekForm(props) {
  const [Titel, setTitel] = useState("");
  const [Beschrijving, setBeschrijving] = useState("");
  const [IsGekeurd, setIsGekeurd] = useState(false);

  const queryClient = useQueryClient();

  const mutation = useMutation(
    (newonderzoek) =>
      axiosInstance.post(
        `${apiPath}/api/BedrijfPortaal/CreateOnderzoek`,
        newonderzoek
      ),
    {
      onSuccess: () => {
        setTitel("");
        setBeschrijving("");
        setIsGekeurd(false);

        queryClient.invalidateQueries("tableData");
      },
    }
  );

  const handleSubmit = (event) => {
    // mutation.mutate({
    //     "Titel": Titel,
    //     "Beschrijving": Beschrijving

    // });


    const OnderzoekData = {
      titel: Titel,
      beschrijving: Beschrijving,
    };
    props.getInfomatie(OnderzoekData);
    setBeschrijving = "";
    setTitel = "";
  };

  return (
    <Container>
      <Card className={"Shadow"}>
        <Card.Body>
          <Form>
            <Row>
              <Col>
                <Form.Group>
                  <Form.Label>Titel onderzoek</Form.Label>
                  <Form.Control
                    type={"text"}
                    placeholder={"Titel onderzoek"}
                    value={Titel}
                    onChange={(e) => setTitel(e.target.value)}
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group>
                  <Form.Label>Beschrijving</Form.Label>
                  <Form.Control
                    type={"text"}
                    placeholder={"Beschrijving"}
                    value={Beschrijving}
                    onChange={(e) => setBeschrijving(e.target.value)}
                  />
                </Form.Group>
              </Col>
            </Row>
          </Form>
        </Card.Body>
      </Card>
    </Container>
  );
}

export default NewOnderzoekForm;
